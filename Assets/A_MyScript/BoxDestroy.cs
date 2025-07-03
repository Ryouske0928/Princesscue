using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] Transform ItemSpawnPoint;  //�h���b�v����ꏊ
    [SerializeField] ItemDatabaseSO DropItem;
    public int _ItemNum;

    private void OnTriggerEnter(Collider other)  //�ǂ����ł���������悤��,Enter��Stay
    {
        BoxDamage(other.tag);
    }
    private void BoxDamage(string tag)�@  //�A�C�e��Box�j�󔻒�
    {
        if (tag == WeaponTag)
        {
            gameObject.SetActive(false);

            Instantiate(DropItem.items[_ItemNum]._itemPrefab, ItemSpawnPoint.position ,Quaternion.identity);�@//�A�C�e���h���b�v
        }
    }
}
