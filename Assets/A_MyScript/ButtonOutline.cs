using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonOutline : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Outline buttonOutline;  // Button�ɐݒ肵��Outline�R���|�[�l���g���A�^�b�`
    [SerializeField] Color selectedColor = Color.blue;
    private Color normalColor = Color.clear;

    // �{�^�����I�����ꂽ��
    public void OnSelect(BaseEventData eventData)
    {
        buttonOutline.effectColor = selectedColor;  //�I�����ꂽ���ɗ֊s�̐F��C�ӂ̐F�ɕύX����@(�����͐ɐݒ�)
        AudioManager.Instance.IsPlaySE("�X�e�[�W�I��");
    }

    // �{�^�����I���������ꂽ��
    public void OnDeselect(BaseEventData eventData)
    {
        buttonOutline.effectColor = normalColor;  // �ʏ�̗֊s�͓���
    }

    //�{�^���Ƀ}�E�X�J�[�\���d�Ȃ����Ƃ���
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonOutline.effectColor = selectedColor;  //�I�����ꂽ���ɗ֊s�̐F��C�ӂ̐F�ɕύX����@(�����͐�)
        AudioManager.Instance.IsPlaySE("�X�e�[�W�I��");
    }

    //�{�^������}�E�X�J�[�\�����O�ꂽ��
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonOutline.effectColor = normalColor;  // �ʏ�̗֊s�͓���
    }
}
