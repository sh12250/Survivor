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
            // return 값이 Tweener 애니메이션이다
            shakeAnim = transform.DOShakeScale(0.5f, 1, 20, 90, true, ShakeRandomnessMode.Harmonic).SetAutoKill();
            shakeAnim.onKill += () => DisposeShakeAnim();
            return;
        }

        // Debug.Log("shakeAnim가 비어있지 않다");
    }

    //! Tween이 kill 될 때 shakeAnim를 비워주는 함수
    private void DisposeShakeAnim()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.localScale = Vector3.one;
        shakeAnim = default;
    }
}
