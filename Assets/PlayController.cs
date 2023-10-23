using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public GameObject SelectionSortChooseLevel;
    public GameObject InterchangeSortChooseLevel;
    public GameObject BubbleSortChooseLevel;
    public GameObject InsertionSortChooseLevel;

    public GameObject ChooseLevel;
    void Start()
    {
        Hide(); 
    }

    public void Hide()
    {
        SelectionSortChooseLevel.SetActive(false);
        InterchangeSortChooseLevel.SetActive(false);
        BubbleSortChooseLevel.SetActive(false);
        InsertionSortChooseLevel.SetActive(false);
    }

    public void OnButton1Click()
    {
        ChooseLevel.SetActive(true);
        SelectionSortChooseLevel.SetActive(true);
    }

    public void OnButton2Click()
    {
        ChooseLevel.SetActive(true);
        InsertionSortChooseLevel.SetActive(true);
    }
    public void OnButton3Click()
    {
        ChooseLevel.SetActive(true);
        BubbleSortChooseLevel.SetActive(true);
    }

    public void OnButton4Click()
    {
        ChooseLevel.SetActive(true);
        InterchangeSortChooseLevel.SetActive(true);
    }


}
