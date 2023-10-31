using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineMode : MonoBehaviour
{
    public GameObject OfflineLabel;
    public GameObject ScorePanel;
    // Update is called once per frame
    void Update()
    {
        string nama = PlayerPrefs.GetString("username");

        if (nama == "!!ERROR!!" || nama == null || nama == "" || nama == " "){
            OfflineLabel.SetActive(true);
            ScorePanel.SetActive(false);
        } else {
            OfflineLabel.SetActive(false);
            ScorePanel.SetActive(true);
        }
    }
}
