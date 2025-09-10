using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    private enum ItemType
    {
        Potion,
        AttackUp,
        Coin
    }
    [Header("アイテム効果")]
    [SerializeField] private ItemType itemType;
    [Header("回復力")]
    [SerializeField] private int _healAmount;
    [Header("攻撃upの値")]
    [SerializeField] private int _attackUp;

    //アイテムの取得当たり判定
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            PlayerCtrl power = other.GetComponentInParent<PlayerCtrl>();
            Health hp = other.GetComponentInParent<Health>();
            BuffStatus buff = other.GetComponentInParent<BuffStatus>();
            GetItem(power, hp, buff);
            Destroy(gameObject);
        }
    }
    
    //アイテム取得時の処理
    void GetItem(PlayerCtrl power, Health hp, BuffStatus buff)
    {
        switch (itemType)
        {
            case ItemType.Potion:　　　　　　　　//ヒールポーション
                hp.Heal(_healAmount);
                break;

            case ItemType.AttackUp:　　　　　　　//火力UPアイテム
                power.OnAttackUp(_attackUp);
                buff.AddBuffStatus("AttackUp");
                break;
            case ItemType.Coin:　　　　　　　　　//自己満コイン

                break;
        }
    }
    
}
