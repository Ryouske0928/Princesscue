using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{
    [SerializeField] Button[] buttons; //インスペクター上で操作したいボタン設定
    private int _selectButtonNum = -1;
    private bool firstSelect = false;  //初回の入力確認フラグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)　|| Input.GetKeyDown(KeyCode.S))
        {
            if(!firstSelect)
            {
                _selectButtonNum = 0; //初回入力で0番目のボタンになるように設定
                firstSelect = true;
            }

            else
            {
                //Wキー入力で上へ移動
                if(Input.GetKeyDown(KeyCode.W))
                {
                    _selectButtonNum--;
                    if(_selectButtonNum < 0)
                    {
                        _selectButtonNum = buttons.Length - 1;
                    }
                }
                //Sキー入力で下へ移動
                if (Input.GetKeyDown(KeyCode.S))
                {
                    _selectButtonNum++;
                    if(_selectButtonNum >= buttons.Length)
                    {
                        _selectButtonNum = 0;
                    }
                }
            }

            SelectButton(_selectButtonNum);  //ボタンを選択状態にする
        }

        //Enterキーで決定
        if(firstSelect && Input.GetKeyDown(KeyCode.Return))
        {
            buttons[_selectButtonNum].onClick.Invoke();
        }
    }

    private void SelectButton(int buttonNum)
    {
        EventSystem.current.SetSelectedGameObject(buttons[buttonNum].gameObject);  //イベントシステムに選択されたボタンを設定

    }
}
