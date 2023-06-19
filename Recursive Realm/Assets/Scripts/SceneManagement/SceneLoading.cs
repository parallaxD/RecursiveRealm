using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [Header("����������� �����")]
    [SerializeField] string sceneName; 
    [Header("��������� �������")]
    [SerializeField] private Image _loadingImage;

    public void LoadSceneAsync()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            _loadingImage.fillAmount = progress;
            yield return null;
        }      
    }

    public static void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
