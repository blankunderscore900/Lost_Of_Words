using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    //public GameObject gameOverPanel;
    //public TextMeshProUGUI yourScoreText;
    //public TextMeshProUGUI highScoreText;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI moveCounterText;
    public TextMeshProUGUI speechPointsText;

    public Image FillBar;

    public float filledBar;
    public float maxFill;
    public int speechPoints;


    public int score;
    public int moveCounter;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text ="Score: " + score.ToString();
        }
    }

    public int MoveCounter
    {
        get
        {
            return moveCounter;
        }
        set
        {
            moveCounter = value;
            if(moveCounter <= 0)
            {
                moveCounter = 0;
                StartCoroutine(WaitForShifting());
            }
            moveCounterText.text = "Moves: " + moveCounter.ToString();

        }
    }

    public int SpeechPoints
    {
        get
        {
            return speechPoints;
        }
        set
        {
            speechPoints = value;
            speechPointsText.text = " - " + speechPoints.ToString() + " - ";
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        speechPoints = 0;
        //moveCounter = 60;
        moveCounterText.text = "Moves: " + moveCounter.ToString();
        speechPointsText.text = " - " + speechPoints.ToString() + " - ";
        scoreText.text = "Score: " + 0;
        instance = GetComponent<GUIManager>();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        //GameManger.instance.gameOver = true;

        //gameOverPanel.SetActive(true);

        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            //highScoreText.text = "New Best: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            //highScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    private IEnumerator WaitForShifting()
    {
        //yield return new WaitUntil(() => !BoardManager.instance.IsShifting);
        yield return new WaitForSeconds(.25f);
        GameOver();
    }


}
