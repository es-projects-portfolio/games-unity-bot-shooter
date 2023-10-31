using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayClosePanel : MonoBehaviour
{
    public GameObject panelClose;
    public GameObject panelOpen1;
    public GameObject panelOpen2;
    public void OnClick()
    {
        StartCoroutine(ClosePanelDelayed());
    }

    private IEnumerator ClosePanelDelayed()
    {
        yield return new WaitForSeconds(5f);    // Wait for 5 seconds
        panelClose.SetActive(false);
        panelOpen1.SetActive(true);
        panelOpen2.SetActive(true);
    }
}
