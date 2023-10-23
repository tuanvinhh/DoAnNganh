using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InsertionSortUI : MonoBehaviour
{
    public Button sortButton; 
    public Button resetButton; 
    public Text[] numbTexts; 
    public TextMeshProUGUI comparisonText; 
    public TextMeshProUGUI insertionPositionText; 
    private int[] insertnumbers; 

    private void Start()
    {
        InitializeNumbers();
        sortButton.onClick.AddListener(PerformInsertionSort);
        resetButton.onClick.AddListener(ResetSorting);
        UpdateTexts();
    }

    private void InitializeNumbers()
    {
        insertnumbers = new int[6];
        for (int i = 0; i < 6; i++)
        {
            insertnumbers[i] = Random.Range(1, 101); 
        }
    }

    private void PerformInsertionSort()
    {
        StartCoroutine(InsertionSortCoroutine());
    }

    private IEnumerator InsertionSortCoroutine()
    {
        for (int i = 1; i < insertnumbers.Length; i++)
        {
            int key = insertnumbers[i];
            int j = i - 1;

            while (j >= 0 && insertnumbers[j] > key)
            {
                numbTexts[j].color = Color.red;
                numbTexts[j + 1].color = Color.red;
                comparisonText.text = "Comparing " + insertnumbers[j] + " and " + key;

                yield return new WaitForSeconds(2.0f); 

                insertnumbers[j + 1] = insertnumbers[j];

                insertionPositionText.text = "Inserting at position " + (j + 1);

                UpdateTexts();

                yield return new WaitForSeconds(2.0f); 

                numbTexts[j].color = Color.white;
                numbTexts[j + 1].color = Color.white;

                j--;
            }

            insertnumbers[j + 1] = key;

            UpdateTexts();
            comparisonText.text = "";
            insertionPositionText.text = "";

            yield return new WaitForSeconds(2.0f); 
        }
        comparisonText.text = "COMPLETED";
    }

    private void ResetSorting()
    {
        StopAllCoroutines(); 

        InitializeNumbers(); 
        UpdateTexts(); 
        comparisonText.text = ""; 
        insertionPositionText.text = ""; 
    }

    private void UpdateTexts()
    {
        for (int i = 0; i < insertnumbers.Length; i++)
        {
            numbTexts[i].text = insertnumbers[i].ToString();
        }
    }
}
