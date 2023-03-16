//�S����:�ێq�
using UnityEngine;

namespace Resistance
{
    /// <summary>
    /// ���^�G�l�~�[�̍U���̔���̃N���X
    /// </summary>
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField]
        private Enemy enemy;
        void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                enemy.OnAttackCollider();
            }
        }
    }
}