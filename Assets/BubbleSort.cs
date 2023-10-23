using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Linq;
using System;

public class BubbleSort : MonoBehaviour
{
    public Text[] numberTexts;
    public Button leftButton;
    public Button rightButton;
    public Button backButton;
    public Button restartButton;
    public TextMeshProUGUI timeText;
    public float gameDuration = 60.0f;
    public TextMeshProUGUI comparisonText;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreText;
    public GameObject chooseSort;
    public GameObject panelLvSort;

    private int[] numbers;
    private int currentPairIndex = 0;
    private bool isSorted = false;
    private double BBSscore = 0;
    private double BBSpenalty = 0.5;
    private bool BBSisTimeUp = false;
    private float currentTime = 0;
    private bool skipLastNumber = false;
    public float maxScore = 10.0f;
    public bool isGameFinished = false;

    void Start()
    {
        GenerateRandomNumbers();
        UpdateUI();
        StartCoroutine(Countdown());
        restartButton.onClick.AddListener(RestartGame);
        backButton.onClick.AddListener(BackToLevelSelection);
    }

    void GenerateRandomNumbers()
    {
        numbers = new int[numberTexts.Length];
        for (int i = 0; i < numberTexts.Length; i++)
        {
            numbers[i] = UnityEngine.Random.Range(1, 101);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < numberTexts.Length; i++)
        {
            numberTexts[i].text = numbers[i].ToString();
        }

        timeText.text = "Thời gian: " + Mathf.Max(0, Mathf.RoundToInt(gameDuration - currentTime)).ToString();
        leftButton.interactable = true;
        rightButton.interactable = true;

        int endIdx = numbers.Length - currentPairIndex - 2;
        if (endIdx >= 0)
        {
            comparisonText.text = $"So sánh: {numbers[currentPairIndex]} và {numbers[currentPairIndex + 1]}";
        }
        else
        {
            comparisonText.text = "";
        }
        scoreText.text = "Score: " + BBSscore.ToString("F2");
    }

    public void OnChooseButtonClick(int index)
    {
        if (isSorted || BBSisTimeUp)
        {
            return;
        }

        int leftNumber = numbers[currentPairIndex];
        int rightNumber = numbers[currentPairIndex + 1];

        if (index == 0) 
        {
            if (leftNumber <= rightNumber)
            {
                Debug.Log("Chọn nút trái...");
                Debug.Log("Giá trị Trái nhỏ hơn, chọn đúng, tăng điểm...");
                resultText.text = "Chọn đúng, tăng điểm...";
                BBSscore += 1.0;
            }
            else
            {
                Debug.Log("Chọn nút trái...");
                Debug.Log("Giá trị Trái không nhỏ hơn, chọn sai, giảm điểm...");
                resultText.text = "Chọn sai, chọn lại, giảm điểm...";
                BBSscore -= BBSpenalty;
                currentPairIndex--;
            }
        }
        else if (index == 1) 
        {
            if (rightNumber <= leftNumber)
            {
                Debug.Log("Chọn nút phải...");
                Debug.Log("Giá trị Phải nhỏ hơn, chọn đúng, hoán đổi và tăng điểm...");
                resultText.text = "Chọn đúng, tăng điểm...";
                BBSscore += 1.0;

                int temp = leftNumber;
                numbers[currentPairIndex] = rightNumber;
                numbers[currentPairIndex + 1] = temp;
                Debug.Log("Hoán đổi");
            }
            else
            {
                Debug.Log("Chọn nút phải...");
                Debug.Log("Giá trị Phải không nhỏ hơn, chọn sai, giảm điểm...");
                resultText.text = "Chọn sai, chọn lại, giảm điểm...";
                BBSscore -= BBSpenalty;
                currentPairIndex--;
            }
        }

        currentPairIndex++;

        BBSscore = Mathf.Clamp((float)BBSscore, 0f, maxScore); 

        if (currentPairIndex >= numbers.Length - 1)
        {
            if (!skipLastNumber)
            {
                skipLastNumber = true;
                currentPairIndex = 0;
            }
            else
            {
                if (IsSorted(numbers))
                {
                    isSorted = true;
                    Debug.Log("Hoàn thành ! Điểm của bạn: " + BBSscore.ToString("F2"));
                    resultText.text = "Hoàn thành! Điểm của bạn: " + BBSscore.ToString("F2");
                    isGameFinished = true;
                }

                currentPairIndex = 0;
                skipLastNumber = false;
            }
        }

        scoreText.text = "Score: " + BBSscore.ToString("F2");
        UpdateUI();
    }


    void BubbleSortLogic()
    {
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }

    bool IsSorted(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator Countdown()
    {
        while (currentTime < gameDuration)
        {
            if (!isSorted)
            {
                currentTime += Time.deltaTime;
                UpdateUI();
            }
            yield return null;
        }
        BBSisTimeUp = true;
        Debug.Log("Hết giờ! Chương trình đã dừng lại.");
        isGameFinished = true;
    }
    void BackToLevelSelection()
    {
        if (isGameFinished)
        {
            chooseSort.SetActive(true);
            panelLvSort.SetActive(false);
            Debug.Log("Chuyển về trang chọn level.");
        }
        else
        {
            Debug.Log("Trò chơi chưa kết thúc, không thể quay về.");
        }
    }
    void RestartGame()
    {
        isSorted = false;
        BBSisTimeUp = false;
        isGameFinished = false;
        currentPairIndex = 0;
        BBSscore = 0;
        currentTime = 0;
        skipLastNumber = false;

        GenerateRandomNumbers();
        StartCoroutine(Countdown());
        UpdateUI();
    }

}
