using UnityEngine;

public class StarSystem : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int attempts = 0;

    void Start()
    {
        ResetStars();
    }

    public void WrongAnswer()
    {
        attempts++;
    }

    public void CorrectAnswer()
    {
        if (attempts == 0)
            ShowStars(3);
        else if (attempts == 1)
            ShowStars(2);
        else
            ShowStars(1);

        attempts = 0;
    }

    private void ShowStars(int count)
    {
        star1.transform.localScale = (count >= 1) ? Vector3.one : Vector3.zero;
        star2.transform.localScale = (count >= 2) ? Vector3.one : Vector3.zero;
        star3.transform.localScale = (count >= 3) ? Vector3.one : Vector3.zero;
    }

    // Yeni soru baþladýðýnda çaðýr
    public void ResetStars()
    {
        star1.transform.localScale = Vector3.zero;
        star2.transform.localScale = Vector3.zero;
        star3.transform.localScale = Vector3.zero;
    }
}
