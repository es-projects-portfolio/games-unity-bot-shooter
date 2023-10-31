using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadingDelay : MonoBehaviour
{
    public string SceneName = "";

    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;

    void Awake(){
        StartCoroutine(delayBall1());
    }

    private IEnumerator delayBall1()
    {
        yield return new WaitForSeconds(2f);    
        ball1.SetActive(true);
        StartCoroutine(delayBall2());
    }

    private IEnumerator delayBall2()
    {
        yield return new WaitForSeconds(2f);    
        ball2.SetActive(true);
        StartCoroutine(delayBall3());
    }

    private IEnumerator delayBall3()
    {
        yield return new WaitForSeconds(2f);    
        ball3.SetActive(true);
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f); 
        SceneManager.LoadScene(SceneName);   
    }

}
