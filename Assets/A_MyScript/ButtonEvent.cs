using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{

    public void LoadInGameScene()   //InGameのロード用
    {
        SceneManager.LoadScene("InGame");
    }
}
