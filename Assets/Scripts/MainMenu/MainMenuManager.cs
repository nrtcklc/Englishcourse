using UnityEngine;
using DG.Tweening;  
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField]
    GameObject logoImg, aileyeNot;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        LogoyuAc();
       // StartCoroutine(BekleVeAc());
    }
    void LogoyuAc()
    {
        logoImg.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        logoImg.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }
    public void SahneyiAc(string sahneninAdi)
    {
        SceneManager.LoadScene(sahneninAdi);
    }  
   /* IEnumerator BekleVeAc()
    {
        yield return new WaitForSeconds(1f);
        aileyeNot.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        aileyeNot.GetComponent<RectTransform>().DOScale(1, 0.5f);
    }*/
}
