using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CodeController : MonoBehaviour
{
    public GameObject SelectionSortCodeConceptPanel;
    public GameObject InterchangeSortCodeConceptPanel;
    public GameObject BubbleSortCodeConceptPanel;
    public GameObject InsertionSortCodeConceptPanel;

    public GameObject PanelSortCode;
    void Start()
    {
        HideConceptCodePanels(); 
    }

    public void HideConceptCodePanels()
    {
        SelectionSortCodeConceptPanel.SetActive(false);
        InterchangeSortCodeConceptPanel.SetActive(false);
        BubbleSortCodeConceptPanel.SetActive(false);
        InsertionSortCodeConceptPanel.SetActive(false);
    }

    public void OnButton1Click()
    {
        PanelSortCode.SetActive(true);
        SelectionSortCodeConceptPanel.SetActive(true);
    }

    public void OnButton2Click()
    {
        PanelSortCode.SetActive(true);
        InsertionSortCodeConceptPanel.SetActive(true);
    }
    public void OnButton3Click()
    {
        PanelSortCode.SetActive(true);
        BubbleSortCodeConceptPanel.SetActive(true);
    }

    public void OnButton4Click()
    {
        PanelSortCode.SetActive(true);
        InterchangeSortCodeConceptPanel.SetActive(true);
    }


}

