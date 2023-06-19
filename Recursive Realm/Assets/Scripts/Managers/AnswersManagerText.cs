using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswersManagerText : MonoBehaviour
{
    [SerializeField] Image ExerciseImage;
    [SerializeField] GameObject MarkObject;
    [SerializeField] TextMeshProUGUI MarkPanelText;
    [SerializeField] GameObject CloseExerciseButton;
    [SerializeField] GameObject VideoButton;
    [SerializeField] TMP_InputField _firstInputField;
    [SerializeField] TMP_InputField _secondInputField;
    [SerializeField] Sprite ImageToReplace;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] AudioClip _goodSound;
    [SerializeField] AudioClip _badSound;

    private int RightAnswersCount;

    private void Awake()
    {
        MarkObject.SetActive(false);
        _firstInputField.characterLimit = 14;
        _secondInputField.characterLimit = 12;
    }

    public void CheckAnswerInputText(string answer)
    {
        var rightAnswer = answer.ToLower().Replace(" ", "");
        if (_firstInputField.text.ToLower().Replace(" ", "") == rightAnswer)
        {
            RightAnswersCount++;
        }
        if (_secondInputField.text.ToLower().Replace(" ", "") == rightAnswer)
        {
            RightAnswersCount++;
        }
    }

    public void CloseExercise(GameObject exercise)
    {
        InputManager.PlayerActions.Interact.Enable();
        GameManager.PlayerUICanvas.SetActive(true);       
        GameManager.ExerciseBackGround.SetActive(false);
        Destroy(exercise);
        GameManager.IsSomeBookOpen = false;
        GameManager.ResumeGame();
    }

    public void RightAnswersCountCheck()
    {
        switch (RightAnswersCount)
        {
            case 0:
                MarkObject.GetComponentInChildren<Image>().color = new Color(255, 0, 0, 1);
                MarkPanelText.text = "К сожалению + 1 балл";
                MarkObject.SetActive(true);
                GameManager.PlayerScore += 1;
                SoundManager.PlaySound(_badSound);
                break;
            case 1:
                MarkObject.GetComponentInChildren<Image>().color = new Color(255, 255, 0, 1);
                MarkPanelText.text = "К сожалению + 2 балла";
                MarkObject.SetActive(true);
                GameManager.PlayerScore += 2;
                SoundManager.PlaySound(_badSound);
                break;

            case 2:
                MarkObject.GetComponentInChildren<Image>().color = new Color(0, 255, 0, 1);
                MarkPanelText.text = "Всё верно! + 3 балла";
                MarkObject.SetActive(true);
                GameManager.PlayerScore += 3;
                SoundManager.PlaySound(_goodSound);
                break;
        }
        ExerciseImage.sprite = ImageToReplace;
    }
}
