using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnime : MonoBehaviour
{
    //剣を振るアニメーションで呼び出してる関数
    [SerializeField] Collider SwordCol;
    void SwordOnEvent()　//剣の当たり判定On & 攻撃時は移動不可に
    {
        SwordCol.enabled = true;
    }

    void SwordOffEvent()　//剣の当たり判定Off & 再度移動可能に
    {
        SwordCol.enabled = false;
    }
}
