using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObject, restartButton, tryAgainButton;

    int score = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increasePoint()
    {
        scoreText.text = score.ToString();
        score++;
    }

    public void showScoreText()
    {
        scoreTextObject.SetActive(true);   
    }

    public void showRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void showTryAgainButton()
    {
        tryAgainButton.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
