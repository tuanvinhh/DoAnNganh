using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;

public class GamePlaySort : MonoBehaviour
{
    public Text[] numberTexts; 
    public Button[] chooseButtons;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countdownText;
    public Button restartButton;
    public Button backButton;

    public GameObject ChooseSort;
    public GameObject Hide;
    private Coroutine countdownCoroutine;
    private int selectedIndex = 0;
    private double score = 0;
    private int[] numbers; 
    private bool[] positionsSorted; 
    private bool isSortingCorrect; 
    public double penalty = 0.5; 
    private int sortedPositionsCount = 0;
    public float countdownTime = 15f; 
    private bool isTimeUp = false; 


    private bool isButtonsInteractable = true;
    private bool isGameFinished = false;
    private bool levelCompleted = false;

    void Start()
    {
        GenerateRandomNumbers();
        UpdateUI(); 
        positionsSorted = new bool[numbers.Length];
        isSortingCorrect = false;
        countdownCoroutine = StartCoroutine(Countdown()); 
        restartButton.onClick.AddListener(RestartGame);
        backButton.onClick.AddListener(BackToLevelSelection);
    }
    void Update()
    {
        if (!levelCompleted && !isTimeUp)
        {
            countdownTime -= Time.deltaTime;
            UpdateUI();
            if (countdownTime <= 0f && !isSortingCorrect)
            {
                isTimeUp = true;
                Debug.Log("Hết thời gian! Chương trình đã dừng.");
                DisableButtons();
                levelCompleted = true;
                isGameFinished = true;
            }
        }
    }
    void GenerateRandomNumbers()
    {
        numbers = new int[6];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = UnityEngine.Random.Range(1, 101);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numberTexts[i].text = numbers[i].ToString();
        }
        countdownText.text = "Time: " + countdownTime.ToString("F0");
        scoreText.text = score.ToString("F2");
    }

    public void OnChooseButtonClick(int index)
    {
        if (isGameFinished)
        {
            Debug.Log("Trò chơi đã kết thúc, bạn có thể quay lại.");
            return;
        }
        if (isButtonsInteractable && !positionsSorted[index] && !isSortingCorrect && !levelCompleted)
        {
            int minIndex = index;
            for (int i = index + 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[minIndex])
                {
                    minIndex = i;
                }
            }

            int temp = numbers[index];
            numbers[index] = numbers[minIndex];
            numbers[minIndex] = temp;

            positionsSorted[index] = true;
            sortedPositionsCount++;

            score += 1.66666666667;
            selectedIndex++;

            if (sortedPositionsCount == numbers.Length)
            {
                isSortingCorrect = true;
                Debug.Log("Sắp xếp đúng!");
                DisableButtons();
                levelCompleted = true;
                isTimeUp = true;
                isGameFinished = true;
            }
            UpdateUI();
        }
        else
        {
            if (levelCompleted)
            {
                Debug.Log("Trò chơi đã kết thúc, không thể chọn nữa.");
            }
            else if (positionsSorted[index])
            {
                score -= penalty;
                Debug.Log("Chọn sai lựa chọn, bị trừ điểm: " + penalty);
                scoreText.text = score.ToString("F2");
            }
            else
            {
                score -= penalty;
                Debug.Log("Chọn sai lựa chọn, bị trừ điểm: " + penalty);
                scoreText.text = score.ToString("F2");
            }
        }
    }


    int FindMinNumberIndexExcept(int exceptIndex)
    {
        int minIndex = (exceptIndex + 1) % numbers.Length;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i != exceptIndex && numbers[i] < numbers[minIndex])
            {
                minIndex = i;

            }
        }
        return minIndex;
    }
    private IEnumerator Countdown()
    {
        while (!isTimeUp && !isSortingCorrect && !levelCompleted)
        {
            countdownTime -= Time.deltaTime;
       
            UpdateUI();
            yield return null;
        }

        if (countdownTime <= 0f && !isSortingCorrect && !levelCompleted)
        {
            isTimeUp = true;
            Debug.Log("Hết thời gian! Chương trình đã dừng.");
        }
    }
    private void DisableButtons()
    {
        isButtonsInteractable = false;
        foreach (var button in chooseButtons)
        {
            button.interactable = false;
        }
    }
    void EnableButtons()
    {
        isButtonsInteractable = true;
        foreach (var button in chooseButtons)
        {
            button.interactable = true;
        }
    }

    void RestartGame()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        countdownCoroutine = StartCoroutine(Countdown());
        isSortingCorrect = false;
        isGameFinished = false;
        isTimeUp = false;
        levelCompleted = false;
        sortedPositionsCount = 0;
        Array.Clear(positionsSorted, 0, positionsSorted.Length);
        countdownTime = 15f;
        score = 0;
        EnableButtons();
        GenerateRandomNumbers();
        UpdateUI();
    }
    void BackToLevelSelection()
    {
        if (isGameFinished)
        {
            ChooseSort.SetActive(true);
            Hide.SetActive(false);
            Debug.Log("Chuyển về trang chọn level.");
        }
        else
        {
            Debug.Log("Trò chơi chưa kết thúc, không thể quay về.");
        }
    }
}