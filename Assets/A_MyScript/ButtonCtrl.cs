using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{
    [SerializeField] Button[] buttons; //�C���X�y�N�^�[��ő��삵�����{�^���ݒ�
    private int _selectButtonNum = -1;
    private bool firstSelect = false;  //����̓��͊m�F�t���O

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)�@|| Input.GetKeyDown(KeyCode.S))
        {
            if(!firstSelect)
            {
                _selectButtonNum = 0; //������͂�0�Ԗڂ̃{�^���ɂȂ�悤�ɐݒ�
                firstSelect = true;
            }

            else
            {
                //W�L�[���͂ŏ�ֈړ�
                if(Input.GetKeyDown(KeyCode.W))
                {
                    _selectButtonNum--;
                    if(_selectButtonNum < 0)
                    {
                        _selectButtonNum = buttons.Length - 1;
                    }
                }
                //S�L�[���͂ŉ��ֈړ�
                if (Input.GetKeyDown(KeyCode.S))
                {
                    _selectButtonNum++;
                    if(_selectButtonNum >= buttons.Length)
                    {
                        _selectButtonNum = 0;
                    }
                }
            }

            SelectButton(_selectButtonNum);  //�{�^����I����Ԃɂ���
        }

        //Enter�L�[�Ō���
        if(firstSelect && Input.GetKeyDown(KeyCode.Return))
        {
            buttons[_selectButtonNum].onClick.Invoke();
        }
    }

    private void SelectButton(int buttonNum)
    {
        EventSystem.current.SetSelectedGameObject(buttons[buttonNum].gameObject);  //�C�x���g�V�X�e���ɑI�����ꂽ�{�^����ݒ�

    }
}
