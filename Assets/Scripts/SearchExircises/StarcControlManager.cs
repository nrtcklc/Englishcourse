using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StarcControlManager : MonoBehaviour
{

    [SerializeField]
    GameObject fullStar1, fullStar2, fullStar3;
    [SerializeField]
    GameObject birghtStar1, birghtStar2, birghtStar3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void FullStar(int gelenDeger)
    {
        if (gelenDeger < 12)
        {
            fullStar1.GetComponent<Image>().fillAmount=gelenDeger/12f;  
            fullStar2.GetComponent<Image>().fillAmount = 0f;
            fullStar3.GetComponent<Image>().fillAmount = 0f;
        }
        else if (gelenDeger >= 12 && gelenDeger < 24)
        {
            fullStar1.GetComponent<Image>().fillAmount=0f;  
            fullStar2.GetComponent<Image>().fillAmount = (gelenDeger - 12) / 12f;
            fullStar3.GetComponent<Image>().fillAmount = 0f;
        }
        else if (gelenDeger >= 24 && gelenDeger < 36)
        {
            fullStar1.GetComponent<Image>().fillAmount=0f;  
            fullStar2.GetComponent<Image>().fillAmount = 0f;
            fullStar3.GetComponent<Image>().fillAmount = (gelenDeger-24) / 12f;
        }   
    }

    public void BirghtStars(int gelenDeger)
    {
        if (gelenDeger < 12)
        {
            birghtStar1.GetComponent<RectTransform>().DOScale(1, 0.2f).SetEase(Ease.OutBack);
            fullStar1.GetComponent<Image>().fillAmount=gelenDeger/12f;
        }
        else if (gelenDeger >= 12 && gelenDeger < 24)
        {
            birghtStar2.GetComponent<RectTransform>().DOScale(1, 0.2f).SetEase(Ease.OutBack);
            fullStar2.GetComponent<Image>().fillAmount = (gelenDeger - 12) / 12f;
        }
        else if (gelenDeger >= 24 && gelenDeger < 36)
        {
            birghtStar3.GetComponent<RectTransform>().DOScale(1, 0.2f).SetEase(Ease.OutBack);
            fullStar2.GetComponent<Image>().fillAmount = (gelenDeger-24) / 12f;
        }
        Invoke("SendBirght", 0.5f);
    }

    public void SendBirght()
    {
        birghtStar1.GetComponent<RectTransform>().DOScale(0, 0.2f);
        birghtStar2.GetComponent<RectTransform>().DOScale(0, 0.2f);
        birghtStar3.GetComponent<RectTransform>().DOScale(0, 0.2f);
    }
}
