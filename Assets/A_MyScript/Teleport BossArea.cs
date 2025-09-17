using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBossArea : MonoBehaviour
{
    [SerializeField] Transform BossZone;  //�{�X�G���A�ւ̃��[�v����W�i���O�j
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.IsPlaySE("���X�{�X��");
            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            other.transform.position = BossZone.position;
            cc.enabled = true;
        }
    }
}
