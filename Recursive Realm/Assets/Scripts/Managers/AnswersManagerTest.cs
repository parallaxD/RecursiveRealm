using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnswersManagerTest : MonoBehaviour
{
    [SerializeField] List<GameObject> AnswersButtons;
    [SerializeField] GameObject MarkObject;
    [SerializeField] TextMeshProUGUI MarkPanelText;
    [SerializeField] GameObject CloseExerciseButton;
    [SerializeField] GameObject VideoButton;
    private void Awake()
    {
        if(MarkObject != null) MarkObject.SetActive(false);
    }
    public void CheckAnswerTest(int score)
    {
        var button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        if (button.tag == "CorrectButton")
        {
            MarkObject.GetComponentInChildren<Image>().color = new Color(0, 255, 0, 1);
        }
        else if (button.tag == "SemiCorrectButton")
        {
            MarkObject.GetComponentInChildren<Image>().color = new Color(255, 255, 0, 1);
        }
        else MarkObject.GetComponentInChildren<Image>().color = new Color(255, 0, 0, 1);

        switch (score)
        {
            case 3:
                button.transform.parent.Find("Indicator").GetComponent<Image>().color = new Color(255, 255, 255, 1);
                MarkObject.SetActive(true);
                break;
            case 2:
                button.transform.parent.Find("Indicator").GetComponent<Image>().color = new Color(255, 255, 255, 1);
                MarkPanelText.text = $"К сожалению + {score} балла";
                MarkObject.SetActive(true);
                break;
            case 1:
                if (button.tag == "CorrectButton")
                {
                    button.transform.parent.Find("Indicator").GetComponent<Image>().color = new Color(255, 255, 255, 1);
                    MarkPanelText.text = "Молодец! Все верно! + 1 балл!";
                    MarkObject.SetActive(true);
                }
                else
                {
                    button.transform.parent.Find("Indicator").GetComponent<Image>().color = new Color(255, 255, 255, 1);
                    MarkPanelText.text = $"К сожалению + {score} балл. Неожиданно?";
                    MarkObject.SetActive(true);
                }
                break;
            case 0:
                button.transform.parent.Find("Indicator").GetComponent<Image>().color = new Color(255, 255, 255, 1);
                MarkObject.GetComponentInChildren<Image>().color = new Color(255, 0, 0, 1);
                MarkPanelText.text = $"Нет, {score} баллов...";
                MarkObject.SetActive(true);
                break;

        }
        foreach (var answerButton in AnswersButtons)
        {
            answerButton.GetComponent<Button>().enabled = false;
        }
        CloseExerciseButton.SetActive(true);
        if (VideoButton != null)
        {
            VideoButton.SetActive(true);
        }
        GameManager.PlayerScore += score;
    }
    public void CloseExercise(GameObject exercise)
    {
        InputManager.PlayerActions.Interact.Enable();
        GameManager.IsExericiseStarted = false;
        GameManager.PlayerUICanvas.SetActive(true);
        GameManager.ExerciseBackGround.SetActive(false);
        Destroy(exercise);
        GameManager.IsSomeBookOpen = false;
        GameManager.ResumeGame();
    }

}
