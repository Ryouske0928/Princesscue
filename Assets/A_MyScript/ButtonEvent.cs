using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{

    public void LoadInGameScene()   //InGame�̃��[�h�p
    {
        SceneManager.LoadScene("InGame");
    }
}
