using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2BGM : MonoBehaviour
{
    [SerializeField] string fieldBGM;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AudioManager.Instance.FadeIn(fieldBGM, 2f, 0.1f));
    }
}
