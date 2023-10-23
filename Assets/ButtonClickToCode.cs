using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject image1Container;
    public GameObject image2Container;
    public GameObject image3Container;
    public GameObject image5Container;

    public GameObject ImageCode;
    private Image imageSelect, imageInsert, imageBubble, imageInterchange;

    void Start()
    {    
        imageSelect = image1Container.GetComponent<Image>();
        imageInsert = image2Container.GetComponent<Image>();
        imageBubble = image3Container.GetComponent<Image>();
        imageInterchange = image5Container.GetComponent<Image>();
        imageSelect.gameObject.SetActive(false);
        imageInsert.gameObject.SetActive(false);
        imageBubble.gameObject.SetActive(false);   
        imageInterchange.gameObject.SetActive(false);
    }

    public void OnButton1Click()
    {
        ImageCode.SetActive(true);
        if (imageSelect.gameObject.activeSelf)
        {
            imageSelect.gameObject.SetActive(false);
        }
        else
        {
            imageSelect.gameObject.SetActive(true);
        }
    }
    public void OnButton2Click()
    {
        ImageCode.SetActive(true);
        if (imageInsert.gameObject.activeSelf)
        {
            imageInsert.gameObject.SetActive(false);
        }
        else
        {
            imageInsert.gameObject.SetActive(true);
        }
    }
    public void OnButton3Click()
    {
        ImageCode.SetActive(true);
        if (imageBubble.gameObject.activeSelf)
        {
            imageBubble.gameObject.SetActive(false);
        }
        else
        {
            imageBubble.gameObject.SetActive(true);
        }
    }
    public void OnButton4Click()
    {
        ImageCode.SetActive(true);
        if (imageInterchange.gameObject.activeSelf)
        {
            imageInterchange.gameObject.SetActive(false);
        }
        else
        {
            imageInterchange.gameObject.SetActive(true);
        }
    }
}
