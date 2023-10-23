using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortController : MonoBehaviour
{
    public GameObject SelectionSortConceptPanel;
    public GameObject InterchangeSortConceptPanel;
    public GameObject BubbleSortConceptPanel;
    public GameObject InsertionSortConceptPanel;

    public GameObject PanelSort;
    void Start()
    {
        HideConceptPanels(); 
    }

    public void HideConceptPanels()
    {
        SelectionSortConceptPanel.SetActive(false);
        InterchangeSortConceptPanel.SetActive(false);
        BubbleSortConceptPanel.SetActive(false);
        InsertionSortConceptPanel.SetActive(false);
    }

    public void OnButton1Click()
    {
        PanelSort.SetActive(true);
        SelectionSortConceptPanel.SetActive(true);
    }

    public void OnButton2Click()
    {
        PanelSort.SetActive(true);
        InsertionSortConceptPanel.SetActive(true);
    }
    public void OnButton3Click()
    {
        PanelSort.SetActive(true);
        BubbleSortConceptPanel.SetActive(true);
    }

    public void OnButton4Click()
    {
        PanelSort.SetActive(true);
        InterchangeSortConceptPanel.SetActive(true);
    }


}
