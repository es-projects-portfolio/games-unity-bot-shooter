using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int score;
    public GameObject claimPanel;
    public GameObject menuPanel;
    // Start is called before the first frame update
    void Awake()
    {
        score = PlayerPrefs.GetInt("score");

        if (score <= 0)
        {
            claimPanel.SetActive(false);
            menuPanel.SetActive(true);
        }
        else if (score > 0)
        {
            claimPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
    }
}
