using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOutline : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Outline buttonOutline;  // Buttonに設定したOutlineコンポーネントをアタッチ
    [SerializeField] Color selectedColor = Color.blue;
    private Color normalColor = Color.clear;

    // ボタンが選択された時
    public void OnSelect(BaseEventData eventData)
    {
        buttonOutline.effectColor = selectedColor;  //選択された時に輪郭の色を任意の色に変更する　(初期は青に設定)
        AudioManager.Instance.IsPlaySE("ステージ選択");
    }

    // ボタンが選択解除された時
    public void OnDeselect(BaseEventData eventData)
    {
        buttonOutline.effectColor = normalColor;  // 通常の輪郭は透明
    }

    //ボタンにマウスカーソル重なったとき時
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonOutline.effectColor = selectedColor;  //選択された時に輪郭の色を任意の色に変更する　(初期は青)
        AudioManager.Instance.IsPlaySE("ステージ選択");
    }

    //ボタンからマウスカーソルが外れた時
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonOutline.effectColor = normalColor;  // 通常の輪郭は透明
    }
}
