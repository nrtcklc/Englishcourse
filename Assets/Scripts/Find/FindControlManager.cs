using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FindControlManager : MonoBehaviour
{
    int bolumSayisi;
    AudioClip clip;
    public bool butonaBasilsinMi;
    int harfAdet;
    public GameObject fadeImg;
    AudioSource audioSource;
    AudioSource[] tümsesKaynaklari;

    void Start()
    {
        StartCoroutine(HarfleriAcRoutine());
        fadeImg.GetComponent<CanvasGroup>().DOFade(0, 2f).OnComplete(BaslangicSesiniCikar);
        butonaBasilsinMi = false;
    }   
    IEnumerator HarfleriAcRoutine()
    {
        SesCikar();
        GameObject obje=this.transform.GetChild(bolumSayisi).gameObject;
        while(harfAdet<3)
        {         
            obje.transform.GetChild(harfAdet).GetComponent<CanvasGroup>().DOFade(1, 0.1f);
            yield return new WaitForSeconds(0.5f);
            harfAdet++;
        }
        butonaBasilsinMi = true;
    }
    void SesCikar()
    {
        butonaBasilsinMi = false;
        Transform obje = this.gameObject.transform.GetChild(bolumSayisi);
        clip = obje.GetComponent<AudioSource>().clip;
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        Invoke("ButonaBasilabilir", clip.length);
    }
    void ButonaBasilabilir()
    {
        butonaBasilsinMi = true;
    }
    void TumSesleriDurdur()
    {
        tümsesKaynaklari = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audio in tümsesKaynaklari)
        {
            audio.Stop();
        }
    }
    public void SesiTekrarEt()
    {
        TumSesleriDurdur();
        SesCikar();
    }
    void BaslangicSesiniCikar()
    {
        if (audioSource)
        {
            audioSource.Play();
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        fadeImg.GetComponent<CanvasGroup>().DOFade(1, 2f);
    }
}
