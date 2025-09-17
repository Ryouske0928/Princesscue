using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{

    public void LoadSelectStageScene()   //InGame�̃��[�h�p
    {
        AudioManager.Instance.IsPlaySE("�^�C�g������");
        SceneManager.LoadScene("StageSelect");
    }

    public void LoadStage1()
    {
        AudioManager.Instance.IsPlaySE("�X�e�[�W����");
        SceneManager.LoadScene("Stage1");
    }

    public void LoadStage2()
    {
        AudioManager.Instance.IsPlaySE("�X�e�[�W����");
        SceneManager.LoadScene("Stage2");
    }

    public void LoadStage3()
    {
        AudioManager.Instance.IsPlaySE("�X�e�[�W����");
        SceneManager.LoadScene("Stage3");
    }

    public void LoadTitle()
    {
        AudioManager.Instance.IsPlaySE("ReturnTitle");
        SceneManager.LoadScene("Title");
    }
}
