using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Backend.Database;
using Backend;
using UnityEngine.SceneManagement;

public class EndGameDb : MonoBehaviour
{
    public DBHandler dbh;
    public InternalDB idb;

    public TMP_Text Score;
    public int currentScore = 0;
    // Start is called before the first frame update

    public string SceneName = "";

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    private void Awake()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        Score.text = "" + currentScore;
        
    }

    public void PostScore()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        dbh.PostDailyScore(currentScore);
        Debug.Log("Total Score = " + currentScore);
        Debug.Log("Current score resets. Current score = " + CurrentScoreReset());
        /*        Score.text = score + "";*/
    }

    public int CurrentScoreReset()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        return currentScore;
    }
}
