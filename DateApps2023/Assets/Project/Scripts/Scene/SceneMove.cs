//担当者:吉田理紗
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Resistance
{
    /// <summary>
    /// ゲームクリアとゲームオーバーの画面遷移に関する処理を行うクラス
    /// </summary>
    public class SceneMove : MonoBehaviour
    {
        [SerializeField]
        private string sceneName = "New Scene";

        [SerializeField]
        private Animator animationImage = null;

        [SerializeField]
        private AudioClip sceneVoice = null;

        [SerializeField]
        private float afterPressTime = 1.0f;

        [SerializeField]
        private float beforeVoiceTime = 1.0f;

        [SerializeField]
        private float changeTime = 20.0f;

        private AudioSource audioSource = null;
        private float time = 0.0f;

        private bool isPlaying = false;
        private bool isSceneChange = false;
        private bool isAnimation = false;

        // Start is called before the first frame update
        void Start()
        {
            if (sceneVoice != null)
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.volume = 1.0f;
                isPlaying = true;
            }
            time = 0.0f;

            isSceneChange = false;
            isAnimation = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isSceneChange)
            {
                NotSceneChange();
            }
            else
            {
                OnSceneChange();
            }
        }

        /// <summary>
        /// 画面が遷移する前に行う
        /// </summary>
        void NotSceneChange()
        {
            time += Time.deltaTime;
            if (time >= changeTime)
            {
                isSceneChange = true;
                time = 0.0f;
            }
            if (isPlaying)
            {
                if (time >= beforeVoiceTime)
                {
                    audioSource.PlayOneShot(sceneVoice);
                    isPlaying = false;
                }
            }
            for (int i = 0; i < Gamepad.all.Count; i++)
            {
                var gamepad = Gamepad.all[i];
                if (gamepad.bButton.wasPressedThisFrame)
                {
                    isSceneChange = true;
                    time = 0.0f;
                }
            }
        }

        /// <summary>
        /// 画面の遷移が開始した際に呼び出す
        /// </summary>
        void OnSceneChange()
        {
            time += Time.deltaTime;

            if (animationImage != null)
            {
                isAnimation = true;
                animationImage.SetTrigger("AcceptStart");
                if (time >= afterPressTime)
                {
                    isAnimation = false;
                    time = 0.0f;
                }
            }
            if (sceneVoice != null)
            {
                audioSource.volume = (float)(1.0 - time / afterPressTime);

            }
            if (!isAnimation)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}