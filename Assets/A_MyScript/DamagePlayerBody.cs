using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerBody : MonoBehaviour
{
    [SerializeField] private Health health;
    private string EnemyTag = "EnemyWeapon";�@//�G�̃^�O
    private string BossTag1 = "BossWeapon1";�@�@�@�@�@�@�@�@�@ //�{�X�Ə��������������Ȃ������悤�ɗp��
    private string BossTag2 = "BossWeapon2";
    private string Boss2Tag1 = "Boss2Weapon1";
    private string Boss2Tag2 = "Boss2Weapon2";
    private string Boss3Tag = "Boss3Weapon";
    public bool hasHitP = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!hasHitP && other.tag == EnemyTag)
        {
            EnemyCtrl enemyCtrl = other.GetComponentInParent<EnemyCtrl>();
            health.TakeDamage(enemyCtrl.enemyATK);�@�@�@     //�G�̍U���͂��Q�Ƃ��ă_���[�W����
            hasHitP = true;
        }

        if(!hasHitP && other.tag == BossTag1)
        {
            BossCtrl bossCtrl = other.GetComponentInParent<BossCtrl>();
            health.TakeDamage(bossCtrl._bossATK1);
            hasHitP = true;
        }
        if (!hasHitP && other.tag == BossTag2)
        {
            BossCtrl bossCtrl = other.GetComponentInParent<BossCtrl>();
            health.TakeDamage(bossCtrl._bossATK2);
            hasHitP = true;
        }

        if (!hasHitP && other.tag == Boss2Tag1)
        {
            Stage2Boss bossCtrl = other.GetComponentInParent<Stage2Boss>();
            health.TakeDamage(bossCtrl._bossATK1);
            hasHitP = true;
        }
        if (!hasHitP && other.tag == Boss2Tag2)
        {
            Stage2Boss bossCtrl = other.GetComponentInParent<Stage2Boss>();
            health.TakeDamage(bossCtrl._bossATK2);
            hasHitP = true;
        }

        if (!hasHitP && other.tag == Boss3Tag)
        {
            S3BossCtrl bossCtrl = other.GetComponentInParent<S3BossCtrl>();
            health.TakeDamage(bossCtrl._bossATK1);
            hasHitP = true;
        }
    }

}
