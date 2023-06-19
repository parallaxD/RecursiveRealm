using UnityEngine;
using TMPro;

public class NumericInput : MonoBehaviour
{
    private TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(string value)
    {
        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] != '1' && value[i] != '2' && value[i] != '3')
            {
                value = value.Remove(i, 1);
                i--;
            }
        }

        inputField.text = value;
    }
}
