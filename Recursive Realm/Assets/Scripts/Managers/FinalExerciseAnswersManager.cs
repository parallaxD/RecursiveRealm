using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class FinalExerciseAnswersManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _questions;
    [SerializeField] private List<GameObject> _answerNumberImages;
    [SerializeField] private TextMeshProUGUI _answerExplain;
    [SerializeField] private GameObject _imageExplain;
    [SerializeField] private TextMeshProUGUI _imageExplainText;
    [SerializeField] private TextMeshProUGUI _amountScoreText;
    [SerializeField] private GameObject _questionsExplain;
    [SerializeField] private GameObject _closeExerciseButton;
    [SerializeField] private GameObject PanelExplain;
    [SerializeField] private Sprite _imageToReplace;
    [SerializeField] private Image _exerciseImage;
    [SerializeField] private GameObject _nextButton;
    private int _amountScore;
    public void CheckAnswer(int score)
    {
        _imageExplain.GetComponent<Image>().color = new Color(255, 0, 0, 200);
        var button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        switch (button.tag)
        {
            case "CorrectButton":
                _imageExplain.GetComponent<Image>().color = new Color(0, 200, 0, 200);
                break;
        }
        _amountScore += score;
        _amountScoreText.text = $"Всего очков: {_amountScore}";

        if (_questions.All(question => !question.activeSelf))
        {
            _closeExerciseButton.SetActive(true);
            _questionsExplain.SetActive(true);
            _imageExplain.SetActive(false);
            PanelExplain.SetActive(false);
            _nextButton.SetActive(false);
            _answerExplain.enabled = false;
            foreach (var item in _answerNumberImages)
            {
                item.SetActive(false);
            }
            _exerciseImage.sprite = _imageToReplace;
            GameManager.PlayerScore += _amountScore;
        }
        
    }
    public void SetExplainText(string text)
    {
        _answerExplain.text = text;
    }

    public void SetImageExplainText(string text)
    {
        _imageExplainText.text = text;
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
