using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerBody : MonoBehaviour
{
    [SerializeField] private Health health;
    private string EnemyTag = "EnemyWeapon";�@//�G�̃^�O
    private string BossTag;�@�@�@�@�@�@�@�@�@ //�{�X�Ə��������������Ȃ������悤�ɗp��
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == EnemyTag)
        {
            EnemyCtrl enemyCtrl = other.GetComponentInParent<EnemyCtrl>();
            health.TakeDamage(enemyCtrl.enemyATK);�@�@�@//�G�̍U���͂��Q�Ƃ��ă_���[�W����
        }

        //if(other.tag == BossTag) �Ń{�X��p�_���[�W��
    }

}
