using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class MenuTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(2, 2, 2), .3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1, 1, 1), .3f);
    }

}
