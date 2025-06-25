using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerBody : MonoBehaviour
{
    [SerializeField] private Health health;
    private string EnemyTag = "EnemyWeapon";　//敵のタグ
    private string BossTag;　　　　　　　　　 //ボスと処理分けしたくなった時ように用意
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == EnemyTag)
        {
            EnemyCtrl enemyCtrl = other.GetComponentInParent<EnemyCtrl>();
            health.TakeDamage(enemyCtrl.enemyATK);　　　//敵の攻撃力を参照してダメージ処理
        }

        //if(other.tag == BossTag) でボス専用ダメージ等
    }

}
