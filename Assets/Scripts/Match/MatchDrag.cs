using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.EventSystems;

public class MatchDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    CanvasGroup canvasGroup;    
    RectTransform rectTransform;

    public bool isDraggable;
    Vector3 originalPosition;

    AudioSource audioSource;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }

    //sürükleme baþladýðýnda
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDraggable = false;
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.8f; //Yarý saydam yap
        canvasGroup.blocksRaycasts = false; //Diðer UI öðeleriyle etkileþime izin ver
        audioSource.Play();
    }

    //sürükleme sýrasýnda   
    public void OnDrag(PointerEventData eventData)
    {
       rectTransform.anchoredPosition += eventData.delta;
    }

    //sürükleme bittiðinde
    public void OnEndDrag(PointerEventData eventData)
    {
       if(!isDraggable)
       {
            rectTransform.DOAnchorPos(originalPosition, 0.5f).SetEase(Ease.OutBack);
            canvasGroup.blocksRaycasts = true; //Diðer UI öðeleriyle etkileþime izin ver
        }else
        {
            canvasGroup.blocksRaycasts = false; //Diðer UI öðeleriyle etkileþime izin ver
            canvasGroup.alpha = 1f; //Tam opak yap

        }
    }
}
