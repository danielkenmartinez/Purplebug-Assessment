using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class characterLimit : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField inputField;
    public int maxCharacterCount = 10;
    public GameObject submit;

    private void Start()
    {
        inputField.characterLimit = maxCharacterCount;
        inputField.onValueChanged.AddListener(OnValueChanged);
        inputField.onSelect.AddListener(OpenKeyboard);
    }

    private void OnValueChanged(string text)
    {
        if (text.Length > maxCharacterCount)
        {
            inputField.text = text.Substring(0, maxCharacterCount);
        }

        if(text.Length > 0)
        {
            submit.active = true;
        }
        else if(text.Length <= 0)
        {
            submit.active = false;

        }
    }

    private void OpenKeyboard(string text)
    {
        // Focus on the input field and open the mobile keyboard.
        inputField.Select();
        inputField.ActivateInputField();
    }
}
