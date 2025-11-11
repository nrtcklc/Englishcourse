using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SearchExecircesManager : MonoBehaviour
{

    [SerializeField]
    GameObject fadeImg;

    int bolumSayisi;

   public bool butonaBasilsinMi;

    AudioSource audioSource;
    AudioClip clip;

    AudioSource[] tümsesKaynaklari;

    StarcControlManager starControlManager;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        starControlManager= FindObjectOfType<StarcControlManager>();
        //audioSource.Play();
    }

    void Start()
    {
        fadeImg.GetComponent<CanvasGroup>().DOFade(0, 2f).OnComplete(BaslangicSesiniCikar);
        SesCikar();
        butonaBasilsinMi = false;
        TumSesleriDurdur();
    }

    void BaslangicSesiniCikar()
    {
        if (audioSource)
        {
            audioSource.Play();
        }
    }

    public void PaneliHaraketEttir()
    {
        if (bolumSayisi>=36)
            return;
        bolumSayisi++;
        starControlManager.BirghtStars(bolumSayisi);
        starControlManager.FullStar(bolumSayisi);
        this.gameObject.GetComponent<RectTransform>().DOLocalMoveX(this.gameObject.GetComponent<RectTransform>().localPosition.x-1280f, 0.5f);
        SesCikar();
        //TumSesleriDurdur();
    }


    void SesCikar()
    {
        butonaBasilsinMi = false;
        Transform obje=this.gameObject.transform.GetChild(bolumSayisi);   
        for (int i = 0; i < 3; i++)
        {        
            if (!obje.GetChild(i).GetComponent<SearchExirciesButtonManager>().dogruMu)
            {
                clip = obje.GetChild(i).GetComponent<AudioSource>().clip;
                break;
            }
        }
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

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        fadeImg.GetComponent<CanvasGroup>().DOFade(1, 2f);
    }
}
