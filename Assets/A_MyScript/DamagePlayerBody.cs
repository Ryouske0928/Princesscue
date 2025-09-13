using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerBody : MonoBehaviour
{
    [SerializeField] private Health health;
    private string EnemyTag = "EnemyWeapon";　//敵のタグ
    private string BossTag1 = "BossWeapon1";　　　　　　　　　 //ボスと処理分けしたくなった時ように用意
    private string BossTag2 = "BossWeapon2";
    public bool hasHitP = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!hasHitP && other.tag == EnemyTag)
        {
            EnemyCtrl enemyCtrl = other.GetComponentInParent<EnemyCtrl>();
            health.TakeDamage(enemyCtrl.enemyATK);　　　     //敵の攻撃力を参照してダメージ処理
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
    }

}
