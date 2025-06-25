using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] Transform ItemSpawnPoint;  //ドロップする場所
    [SerializeField] ItemDatabaseSO DropItem;

    private void OnTriggerEnter(Collider other)  //どっちでも反応するように,EnterとStay
    {
        BoxDamage(other.tag);
    }
    private void BoxDamage(string tag)　  //アイテムBox破壊判定
    {
        if (tag == WeaponTag)
        {
            gameObject.SetActive(false);

            Instantiate(DropItem.items[0]._itemPrefab, ItemSpawnPoint.position ,Quaternion.identity);　//アイテムドロップ
        }
    }
}
