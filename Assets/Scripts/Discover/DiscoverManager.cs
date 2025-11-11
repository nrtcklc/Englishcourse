using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiscoverManager : MonoBehaviour
{
    [SerializeField]
    GameObject letterPrefab;
    [SerializeField]
    Transform letterHolder;
    [SerializeField]
    AudioClip[] lettersSounds;
    string[] letters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
    int letterIndex;
    public GameObject fadeImg;

    void Start()
    {
        SortLetters();
        fadeImg.GetComponent<CanvasGroup>().DOFade(0, 2f);
    }   

    //Harfleri sýralama fonksiyonu
    void SortLetters()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            GameObject letterImage = Instantiate(letterPrefab,letterPrefab.transform.position, Quaternion.identity);
            letterImage.transform.GetChild(0).GetComponent<Text>().text = letters[i];
            letterImage.transform.SetParent(letterHolder);
            letterHolder.localPosition= new Vector3(3215,0,0);
            letterImage.name = letters[i];
        }
        StartCoroutine(AnimateLetters());
    }

    IEnumerator AnimateLetters()
    {
        while(letterIndex<letters.Length)
        {
            letterHolder.GetChild(letterIndex).GetComponent<CanvasGroup>().DOFade(1,0.5f);
            letterHolder.GetChild(letterIndex).GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
            letterHolder.GetChild(letterIndex).GetComponent<AudioSource>().clip= lettersSounds[letterIndex];
            yield return new WaitForSeconds(0.2f);
            letterIndex++;
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        fadeImg.GetComponent<CanvasGroup>().DOFade(1, 2f);
    }

}
