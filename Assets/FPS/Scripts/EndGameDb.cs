/*using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Backend.Database;

public class EndGameDb : MonoBehaviour
{
    public NewDBHandler dbh;
    public NewInternalDB idb;
    public GameObject OfflineLabel;

    public Time time;
    public TMP_Text CurrentScoreText;
    public int currentScore = 0;

    User user = new User();
    public int DailyScore;

    private void Awake()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        CurrentScoreText.text = "" + currentScore;
        if (idb.nama() == "OFFLINE")
        {
            OfflineLabel.SetActive(true);
        }
        else
        {
            OfflineLabel.SetActive(false);
        }
    }


    //This will happen when the user proceed to main menu or play again scene
    //Call CurrentScore (PlayerPrefs) to add with DailyScore (Db)
    //DailyScore = DailyScore + CurrentScore
    public void NextScene()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        name = PlayerPrefs.GetString("username");

        DailyScore = DailyScoreDB(currentScore);

        dbh.PostDailyScore();
        Debug.Log("Total Score = " + DailyScore);
        Debug.Log("Current score resets. Current score = " + CurrentScoreReset());

    }


    public int DailyScoreDB(int cs)
    {
        int ScoreFromDB = PlayerPrefs.GetInt("DailyScore");
        int finalScore = ScoreFromDB + cs;
        PlayerPrefs.SetInt("DailyScore", finalScore);
        return finalScore;

    }

    public int CurrentScoreReset()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        return currentScore;
    }
}
*/