using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonPageController : MonoBehaviour
{
    public GameObject PanelSortConceptPanel;
    public GameObject PanelSortCodeConceptPanel;
    public GameObject ImageSort;

    public void HideConceptPanels()
    {
        PanelSortConceptPanel.SetActive(false);
        PanelSortCodeConceptPanel.SetActive(false);
        ImageSort.SetActive(false);

    }
    void Start()
    {
        HideConceptPanels();
    }


    void Update()
    {
        
    }
}
