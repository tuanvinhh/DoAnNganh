using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPage : MonoBehaviour
{
    public GameObject PanelLvSort;
    public void Hide()
    {
        PanelLvSort.SetActive(false);
    }
    void Start()
    {
        Hide();
    }


    void Update()
    {

    }
}
