using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class caretColor : MonoBehaviour
{
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text textMeshPro = inputField.textComponent;
        if (textMeshPro != null) {
            textMeshPro.color = Color.grey;
        }
    }
    public void ClearP()
    {
        inputField.placeholder.GetComponent<TextMeshProUGUI>().text = "";
    }
}
