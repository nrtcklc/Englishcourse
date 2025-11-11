using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MatchDrop : MonoBehaviour, IDropHandler
{

    [SerializeField]
    string letter;
    GameObject carriedLetter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        carriedLetter = eventData.pointerDrag;
        if (letter == carriedLetter.transform.GetChild(0).GetComponent<Text>().text)
        {
            carriedLetter.GetComponent<MatchDrag>().isDraggable = true;
            carriedLetter.transform.position = this.transform.position;
            carriedLetter.transform.rotation = this.transform.rotation;
        }
    }

}
