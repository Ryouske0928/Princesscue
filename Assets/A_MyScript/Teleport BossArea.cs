using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBossArea : MonoBehaviour
{
    [SerializeField] Transform BossZone;  //ボスエリアへのワープ先座標（扉前）
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.IsPlaySE("ラスボス門");
            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            other.transform.position = BossZone.position;
            cc.enabled = true;
        }
    }
}
