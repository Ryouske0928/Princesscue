using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBossBgm : MonoBehaviour
{
    [SerializeField] string bossBGM;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag ("Player"))
        {
            StartCoroutine(StartBossBattle());
        }
    }

    private IEnumerator StartBossBattle()
    {
        yield return StartCoroutine(AudioManager.Instance.FadeIn(bossBGM, 2f, 0.2f));
        gameObject.SetActive(false);
    }
}
