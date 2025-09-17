using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] ItemDatabaseSO DropItem;
    public int _ItemNum;
    private Vector3 ItemDropPosition;

    private void OnTriggerEnter(Collider other)  //どっちでも反応するように,EnterとStay
    {
        BoxDamage(other.tag);
    }
    private void BoxDamage(string tag)　  //アイテムBox破壊判定
    {
        if (tag == WeaponTag)
        {
            AudioManager.Instance.IsPlaySE("木箱破壊");
            gameObject.SetActive(false);
            ItemDropPosition = transform.position;
            ItemDropPosition.y += 0.5f;                     //地面に埋まるため、位置調整
            Instantiate(DropItem.items[_ItemNum]._itemPrefab, ItemDropPosition ,Quaternion.identity);　//アイテムドロップ
        }
    }
}
