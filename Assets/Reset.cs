/*using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public TMP_Text TotalScoreText;
    public void ResetValue()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("TotalScore", 0);
        PlayerPrefs.SetInt("TokensClaimed", 0);
        DisplayValue();
    }

    private void DisplayValue()
    {
        int CurrentScore = PlayerPrefs.GetInt("CurrentScore");
        int TotalScore = PlayerPrefs.GetInt("TotalScore");
        int TokensClaimed = PlayerPrefs.GetInt("TokensClaimed");

        Debug.Log("Resetting ..");
        PostToDb();
        Debug.Log("Current score = " + CurrentScore);
        Debug.Log("Total score = " + TotalScore);
        Debug.Log("Tokens Claimed = " + TokensClaimed);
        TotalScoreText.text = TotalScore + "";
    }

    private void PostToDb()
    {
        string db_url = PlayerPrefs.GetString("db_url");
        string db_key_write = PlayerPrefs.GetString("db_key_write");
        User user = new User();
        name = PlayerPrefs.GetString("username");
        if (name != null || name != "")
        {
            RestClient.Put(db_url + name + db_key_write, user);
        }
        
            
    }
}
*/