using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutFieldBGM : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOutFBGM());
        }
    }

    private IEnumerator FadeOutFBGM()
    {
        yield return StartCoroutine(AudioManager.Instance.FadeOut(2f));
        gameObject.SetActive(false);
    }
}
