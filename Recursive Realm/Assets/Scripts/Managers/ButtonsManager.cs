using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    public void OpenExercise(GameObject exercise)
    {
        exercise.SetActive(true);
    }
    public void OpenTheory(GameObject exercise)
    {
        exercise.SetActive(false);
    }
}
