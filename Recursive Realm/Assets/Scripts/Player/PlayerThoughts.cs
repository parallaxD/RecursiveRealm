using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerThoughts : MonoBehaviour
{
    public static TextMeshProUGUI PlayerThoughtsText;
    public static CanvasGroup CanvasGroup;

    private static float _duration;
    private static Coroutine currentThoughtCoroutine;
    private static PlayerThoughts instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _duration = 1.5f;
        CanvasGroup = GameObject.Find("PlayerThoughtText").GetComponent<CanvasGroup>();
        CanvasGroup.alpha = 0f;

        PlayerThoughtsText = GameObject.Find("PlayerThoughtText").GetComponent<TextMeshProUGUI>();

        currentThoughtCoroutine = StartCoroutine(Thought("Что? Где я? Что это за место?"));
    }


    public static IEnumerator Thought(string thoughtText)
    {
        if (currentThoughtCoroutine != null)
        {
            instance.StopCoroutine(currentThoughtCoroutine);
            currentThoughtCoroutine = null;
        }

        PlayerThoughtsText.text = string.Empty;
        yield return new WaitForSeconds(0.2f);
        PlayerThoughtsText.text = thoughtText;
        CanvasGroup.alpha = 0f;
        float time = 0f;
        while (time < _duration)
        {
            CanvasGroup.alpha = Mathf.Lerp(0, 1f, time / _duration);
            time += Time.deltaTime;
            yield return null;
        }
        time = 0;

        yield return new WaitForSeconds(1.5f);

        while (time < _duration)
        {
            CanvasGroup.alpha = Mathf.Lerp(1, 0f, time / _duration);
            time += Time.deltaTime;
            yield return null;
        }

        currentThoughtCoroutine = null;
    }
}
