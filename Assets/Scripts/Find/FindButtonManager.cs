using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindButtonManager : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource[] tümsesKaynaklari;
    public bool dogruMu;
    FindControlManager findControlManager;
 

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        findControlManager = FindObjectOfType<FindControlManager>();
    }
    public void SesCikar()
    {
        if (audioSource && findControlManager.butonaBasilsinMi)
        {
            TumSesleriDurdur();
            audioSource.Play();
            
        }
        if (dogruMu && findControlManager.butonaBasilsinMi)
        {
            TumSesleriDurdur();
            audioSource.Play();
        }
    }
    void TumSesleriDurdur()
    {
        tümsesKaynaklari = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audio in tümsesKaynaklari)
        {
            audio.Stop();
        }
    }
}
