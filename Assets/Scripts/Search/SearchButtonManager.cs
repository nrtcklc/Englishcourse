using UnityEngine;

public class SearchButtonManager : MonoBehaviour
{

    AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButonSesiniOynat()
    {
        if (audioSource)
            audioSource.Play();
    }
}
