using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    public GameClear gameClear;
    private void Start()
    {
        //gameClear = GetComponent<GameClear>();
    }
    private void OnTriggerEnter(Collider other)  //どっちでも反応するように,EnterとStay
    {
        Damage(other.tag);
    }

    private void OnTriggerStay(Collider other)
    {
        Damage(other.tag);
    }

    private void Damage(string tag)　  //ダメージ判定
    {
        Debug.Log("当たった" + tag);
        if (tag == WeaponTag)
        {
            gameClear.DefeatBoss = true;
            Destroy(gameObject);
        }
    }
}
