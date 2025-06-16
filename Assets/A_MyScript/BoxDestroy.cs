using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] Transform ItemSpawnPoint;
    [SerializeField] ItemDatabaseSO DropItem;

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)  //どっちでも反応するように,EnterとStay
    {
        BoxDamage(other.tag);
    }

    private void OnTriggerStay(Collider other)
    {
        BoxDamage(other.tag);
    }

    private void BoxDamage(string tag)　  //アイテムBox破壊判定
    {
        Debug.Log("箱破壊！" + tag);
        if (tag == WeaponTag)
        {
            gameObject.SetActive(false);
            Debug.Log("drop");

            Instantiate(DropItem.items[0]._itemPrefab, ItemSpawnPoint.position ,Quaternion.identity);
        }
    }
}
