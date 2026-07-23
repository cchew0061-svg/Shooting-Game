using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    //updates the prompt message to match the object
    public void UpdateText(string promptMessage)
    {
	promptText.text = promptMessage;
    }
}

