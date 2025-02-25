﻿//担当者:武田碧
using UnityEngine;

/// <summary>
/// ビームの狙う場所
/// </summary>
public class TargetV3D : MonoBehaviour
{

    public Transform targetCursor = null;
    public float speed = 1f;

    const float CENTER_POS = 0.0f;
    const float RIGHT_POS = 1.0f;
    const float LEFT_POS = -0.1f;


    //private Vector3 mouseWorldPosition;

    [SerializeField]
    Transform bossPosition = null;

    [SerializeField]
    Transform targetCenter = null;
    [SerializeField]
    Transform targetRight = null;
    [SerializeField]
    Transform targetLeft = null;


    // Positioning cursor prefab
    void FixedUpdate()
    {
        if (bossPosition.position.x == CENTER_POS)
        {
            Quaternion toRotation = Quaternion.LookRotation(targetCenter.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
            targetCursor.position = targetCenter.position;
        }

        if (bossPosition.position.x >= RIGHT_POS)
        {
            Quaternion toRotation = Quaternion.LookRotation(targetRight.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
            targetCursor.position = targetRight.position;
        }

        if (bossPosition.position.x <= LEFT_POS)
        {
            Quaternion toRotation = Quaternion.LookRotation(targetLeft.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
            targetCursor.position = targetLeft.position;
        }


    }
}