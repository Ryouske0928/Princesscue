using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectBGM : MonoBehaviour
{
    [SerializeField] string stageSelectBGM;

    private void Start()
    {
        StartCoroutine(AudioManager.Instance.FadeIn(stageSelectBGM, 2f, 0.1f));
    }
}
