using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Computer : Interactable
{
    [SerializeField] private GameObject _recursionFirst;
    [SerializeField] private GameObject _recursionSecond;
    [SerializeField] private GameObject _firstExercise;
    [SerializeField] private GameObject _practiceExercise;
    [SerializeField] private List<GameObject> _notebookContent;


    protected override void Interact()
    {
        if (!GameManager.IsPlayerHasNotebook)
        {
            StartCoroutine(PlayerThoughts.Thought("Странно... Не включается"));
        }
        if (!HasInteracted && GameManager.IsPlayerHasNotebook && GameManager.CurrentPart == GameManager.GameParts.ZeroPart)
        {
            SoundManager.PlaySound(InteractSound);
            _recursionFirst.SetActive(true);
            StartCoroutine(PlayerThoughts.Thought("Что это появилось на экране? Рекурсия?"));
           foreach(var content in _notebookContent)
            {
                content.SetActive(true);
            }
            HasInteracted = true;
            GameManager.CurrentPart = GameManager.GameParts.FirstPart;
            StartCoroutine(GameManager.StartExcercise(_firstExercise));
        }
        else if(GameManager.CurrentPart == GameManager.GameParts.SecondPart)
        {
            SoundManager.PlaySound(InteractSound);
            _recursionSecond.SetActive(true);
            StartCoroutine(PlayerThoughts.Thought("Что? Он снова включился?!"));
            StartCoroutine(GameManager.StartExcercise(_practiceExercise));
        }
    }
}
