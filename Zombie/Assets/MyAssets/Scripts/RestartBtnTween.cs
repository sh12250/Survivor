using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RestartBtnTween : MonoBehaviour, IPointerEnterHandler
{
    Tween shakeAnim = default;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("!!!");

        if (shakeAnim == null && shakeAnim == default)
        {
            // return ���� Tweener �ִϸ��̼��̴�
            shakeAnim = transform.DOShakeScale(0.5f, 1, 20, 90, true, ShakeRandomnessMode.Harmonic).SetAutoKill();
            shakeAnim.onKill += () => DisposeShakeAnim();
            return;
        }

        // Debug.Log("shakeAnim�� ������� �ʴ�");
    }

    //! Tween�� kill �� �� shakeAnim�� ����ִ� �Լ�
    private void DisposeShakeAnim()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.localScale = Vector3.one;
        shakeAnim = default;
    }
}
