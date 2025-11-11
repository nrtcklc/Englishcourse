using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverLetterManager : MonoBehaviour
{
    GameObject picturesHolder;


    void Start()
    {
        picturesHolder = GameObject.Find("ResimlerHolder");
    }

    void Update()
    {
      
    }
    public void OpenPictureHolder()
    {
        this.gameObject.GetComponent<RectTransform>().localScale = Vector3.zero;
        picturesHolder.gameObject.SetActive(true);
    }
}
