using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backend.Database;

public class GameAwake : MonoBehaviour
{
    [SerializeField]
    public NewDBHandler dbh;
    [SerializeField]
    public NewInternalDB idb;
    private void Awake()
    {
        idb.GameStart();
        dbh.GetJSON();
        idb.TotalScoreText.text = idb.TotalScore() + "";
        idb.TotalTokenText.text = idb.TotalScore() + " " + idb.token_id();

    }
}
