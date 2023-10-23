using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class InterchangeSort : MonoBehaviour
{
    // Các biến public để thêm các thành phần UI và cài đặt giá trị từ trình chỉnh động
    public GameObject ChooseLv;
    public GameObject Hide;
    public Text[] ICnumberTexts;
    public Button[] ICchooseButtons;
    public TextMeshProUGUI ICscoreText;
    public TextMeshProUGUI ICmessageText;
    public TextMeshProUGUI ICcountdownText;
    public TextMeshProUGUI currentPositionText;
    public Button playAgainButton;
    public Button backChooseLvButton;



    // Các biến private để lưu trạng thái và dữ liệu trong trò chơi
    private int ICselectedIndex = 0;
    private double ICscore = 0;
    private int[] ICnumbers;
    private bool ICisSortingCorrect;
    private bool ICisTimeUp = false;
    private bool ICisButtonsInteractable = true;
    private bool isGameFinished = false;


    // Các biến public để cài đặt các giá trị cố định
    public double ICpenalty = 1.5; 
    public float ICcountdownTime = 60f; 

    void Start()
    {
        GenerateRandomNumbers(); 
        UpdateUI(); 
        ICisSortingCorrect = false;
        StartCoroutine(Countdown()); 
        playAgainButton.onClick.AddListener(PlayAgain);
        backChooseLvButton.onClick.AddListener(BackToLevelSelection);

    }

    void Update()
    {
        if (!ICisTimeUp)
        {
            ICcountdownTime -= Time.deltaTime;
            if (ICcountdownTime <= 0f && !ICisSortingCorrect)
            {
                ICisTimeUp = true;
                Debug.Log("Hết thời gian! Chương trình đã dừng.");
                DisableButtons();
                isGameFinished = true;
            }
        }
    }
    void GenerateRandomNumbers()
    {
        ICnumbers = new int[6];
        for (int i = 0; i < ICnumbers.Length; i++)
        {
            ICnumbers[i] = Random.Range(1, 101); 
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < ICnumbers.Length; i++)
        {
            ICnumberTexts[i].text = ICnumbers[i].ToString(); 
        }

        ICcountdownText.text = "Time: " + ICcountdownTime.ToString("F0");
        ICscoreText.text = ICscore.ToString("F2"); 
        currentPositionText.text = "Đổi chỗ vị trí a[" + ICselectedIndex.ToString() + "] và: ";
    }

    public void OnChooseButtonClick(int index)
    {
        if (ICisButtonsInteractable && !ICisSortingCorrect)
        {
            int minIndex = ICselectedIndex;

            for (int i = ICselectedIndex + 1; i < ICnumbers.Length; i++)
            {
                if (ICnumbers[i] < ICnumbers[minIndex])
                {
                    minIndex = i;
                }
            }

            if (minIndex == index)
            {
                SwapNumbers(ICselectedIndex, minIndex);
                double maxScore = 10.0;
                double increment = maxScore / (ICnumbers.Length - 1);
                ICscore += increment;
                ICselectedIndex++;
                UpdateUI();

                if (ICselectedIndex >= ICnumbers.Length - 1)
                {
                    ICmessageText.text = "Hoàn thành màn chơi!";
                    ICisSortingCorrect = true;
                    isGameFinished = true;
                    DisableButtons();
                    StopCoroutine(Countdown());
                    UpdateUI();                  
                }
                else
                {
                    ICmessageText.text = "Chọn đúng, cộng điểm!";
                }
            }
            else
            {
                ICscore -= ICpenalty;
                ICmessageText.text = "Chọn sai số nhỏ nhất, bị trừ điểm: " + ICpenalty;
                ICscoreText.text = ICscore.ToString("F2");
            }
        }
    }

    void SwapNumbers(int index1, int index2)
    {
        int temp = ICnumbers[index1];
        ICnumbers[index1] = ICnumbers[index2];
        ICnumbers[index2] = temp;
    }

    private IEnumerator Countdown()
    {
        for (int i = 60; i >= 0 && !ICisSortingCorrect; i--)
        {
            ICcountdownTime = i;
            UpdateUI();
            yield return new WaitForSeconds(1f);
        }

        if (ICcountdownTime <= 0f && !ICisSortingCorrect)
        {
            ICisTimeUp = true;
            Debug.Log("Hết thời gian! Chương trình đã dừng.");
            DisableButtons();
        }
    }

    private void DisableButtons()
    {
        ICisButtonsInteractable = false;
        foreach (var button in ICchooseButtons)
        {
            button.interactable = false;
        }
    }
    void PlayAgain()
    {
        ICisSortingCorrect = false;
        ICisTimeUp = false;
        ICisButtonsInteractable = true;
        ICscore = 0;
        ICselectedIndex = 0;
        ICmessageText.text = "";
        ICcountdownTime = 60f;
        GenerateRandomNumbers();
        UpdateUI();
        StartCoroutine(Countdown());
        EnableButtons();
    }
    void EnableButtons()
    {
        ICisButtonsInteractable = true;
        foreach (var button in ICchooseButtons)
        {
            button.interactable = true;
        }
    }
    void BackToLevelSelection()
    {
        if (isGameFinished)
        {
            ChooseLv.SetActive(true);
            Hide.SetActive(false);
            Debug.Log("Chuyển về trang chọn level.");
        }
        else
        {
            Debug.Log("Trò chơi chưa kết thúc, không thể quay về.");
        }
    }
}
