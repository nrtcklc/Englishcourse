using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class AileyeNotManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField]
    Text ikiSaniyeBasiliTutText;
    [SerializeField]
    Image doldurulacakDaire;
    [SerializeField]
    GameObject aileyeNot;
    [SerializeField]
    GameObject aileyenotBtn;

    bool butonbasilimi;

    float basilitutmaSuresi;
    float toplamBasilacakSure = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Update()
    {
        if (butonbasilimi)
        {
            ikiSaniyeBasiliTutText.gameObject.SetActive(true);
            basilitutmaSuresi +=Time.deltaTime;
            if (basilitutmaSuresi >= toplamBasilacakSure)
            {
                butonbasilimi=false;
                ikiSaniyeBasiliTutText.gameObject.SetActive(false);
                //aileyeNot.SetActive(true); 
                aileyeNot.GetComponent<RectTransform>().DOScale(1, 0.5f);
                aileyenotBtn.gameObject.SetActive(false);
            }
            doldurulacakDaire.fillAmount = basilitutmaSuresi/toplamBasilacakSure;
        }

        if(!butonbasilimi)
        {
            basilitutmaSuresi-=Time.deltaTime;  
            if (basilitutmaSuresi <= 0)
            {
                basilitutmaSuresi = 0;
            }
            ikiSaniyeBasiliTutText.gameObject.SetActive(false);
            doldurulacakDaire.fillAmount = basilitutmaSuresi / toplamBasilacakSure;
        }
    }
    public void AileyeNotKapat()
    {
        //aileyeNot.SetActive(false);
        basilitutmaSuresi = 0;
        butonbasilimi = false;
        aileyeNot.GetComponent<RectTransform>().DOScale(0, 0.5f);
        aileyenotBtn.gameObject.SetActive(true);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        butonbasilimi = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        butonbasilimi = false;
    }
}
