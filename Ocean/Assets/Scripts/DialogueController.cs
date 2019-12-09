using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] GameObject DialogueBox;
    [SerializeField] private Text DialogueText;
    public bool DialogueActive;
    public string[] DialogueLines;
    public int CurrentDialogueLine;

    // Update is called once per frame
    void Update()
    {
        if(DialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            CurrentDialogueLine++;
        }

        if(CurrentDialogueLine >= DialogueLines.Length)
        {
            DialogueBox.SetActive(false);
            DialogueActive = false;
            CurrentDialogueLine = 0;
        }

        DialogueText.text = DialogueLines[CurrentDialogueLine];
    }

    public void ShowDialogueBox(string Dialogue)
    {
        DialogueBox.SetActive(true);
        DialogueActive = true;
        DialogueText.text = Dialogue;
    }

    public void ShowDialogue()
    {
        DialogueBox.SetActive(true);
        DialogueActive = true;
    }
}
