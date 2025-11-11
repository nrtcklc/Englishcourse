using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class DiscoverButtonManager : MonoBehaviour
{
    AudioSource audioSource;
    Transform allLettersPanel;
    GameObject image;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        allLettersPanel = GameObject.Find("AllLetters").transform;
    }
    public void SesiCikar()
    {
        if (audioSource.clip != null)
        {
            image = this.gameObject;
            audioSource.Play();
            Invoke("OpenNewLetter", audioSource.clip.length);
        }
    }
    void OpenNewLetter()
    { 
        for (int i = 0; i < allLettersPanel.childCount; i++)
        {
            if (image.name == allLettersPanel.GetChild(i).gameObject.name)
            {
                image.transform.parent.gameObject.SetActive(false);
                allLettersPanel.GetChild(i).GetComponent<RectTransform>().localScale = Vector3.one;
                break;
            }
        }
    }
}
