using UnityEngine;
using DG.Tweening;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class SearchAlistirmaManager : MonoBehaviour
{

    [SerializeField]
    GameObject fadeImg;

    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.Play();
    }

    void Start()
    {
        fadeImg.GetComponent<CanvasGroup>().DOFade(0, 2f).OnComplete(BaslangicSesiniCikar);
       
    }

    void BaslangicSesiniCikar()
    {
        if (audioSource)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SahneyeGec(string sahneAdi)
    {
        SceneManager.LoadScene(sahneAdi);
    }
}
