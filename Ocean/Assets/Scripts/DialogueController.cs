using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject DialogueBox;
    [SerializeField] private Text DialogueText;
    private bool DialogueActive;

    // Update is called once per frame
    void Update()
    {
        if(DialogueActive && Input.anyKey)
        {
            DialogueBox.SetActive(false);
            DialogueActive = false;
        }
    }

    public void ShowDialogueBox(string Dialogue)
    {
        DialogueBox.SetActive(true);
        DialogueActive = true;
        DialogueText.text = Dialogue;

    }
}
