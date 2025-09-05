using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;
    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;
    public float typingspeed = 0.1f;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        if (Instance == null)
            Instance = this;

    }

    //void update 
    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue)
    {

        lines = new Queue<DialogueLine>();

        isDialogueActive = true;

        animator.Play("show");

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }
    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));

    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }
    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("hide");
    }
}
