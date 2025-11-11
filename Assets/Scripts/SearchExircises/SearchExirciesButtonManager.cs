using UnityEngine;

public class SearchExirciesButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    AudioSource audioSource;
    public bool dogruMu; 
    
    SearchExecircesManager searchExecircesManager;

    AudioSource[] tümsesKaynaklari;

    StarSystem starSystem;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        searchExecircesManager = Object.FindObjectOfType<SearchExecircesManager>();
        starSystem = FindObjectOfType<StarSystem>();
    }

    public void SesCikar()
    {
        if (audioSource && searchExecircesManager.butonaBasilsinMi)
        {
            TumSesleriDurdur();
            audioSource.Play();
        }
            

        if (dogruMu && searchExecircesManager.butonaBasilsinMi)
        {
            TumSesleriDurdur();
            searchExecircesManager.PaneliHaraketEttir();
            starSystem.CorrectAnswer();
            Invoke("ResetStarsFNC", 1f);
        }
        if (!dogruMu)
        {
           starSystem.WrongAnswer();
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

    void ResetStarsFNC()
    {
                starSystem.ResetStars();
    }
}
