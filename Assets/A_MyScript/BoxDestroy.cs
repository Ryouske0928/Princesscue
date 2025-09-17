using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
    [SerializeField] string WeaponTag = "Sword";
    [SerializeField] ItemDatabaseSO DropItem;
    public int _ItemNum;
    private Vector3 ItemDropPosition;

    private void OnTriggerEnter(Collider other)  //�ǂ����ł���������悤��,Enter��Stay
    {
        BoxDamage(other.tag);
    }
    private void BoxDamage(string tag)�@  //�A�C�e��Box�j�󔻒�
    {
        if (tag == WeaponTag)
        {
            AudioManager.Instance.IsPlaySE("�ؔ��j��");
            gameObject.SetActive(false);
            ItemDropPosition = transform.position;
            ItemDropPosition.y += 0.5f;                     //�n�ʂɖ��܂邽�߁A�ʒu����
            Instantiate(DropItem.items[_ItemNum]._itemPrefab, ItemDropPosition ,Quaternion.identity);�@//�A�C�e���h���b�v
        }
    }
}
