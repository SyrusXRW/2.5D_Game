using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("Ui Refrences")]
    public Image portrait;
    public TMP_Text actorName;
    public TMP_Text dialogueText;
    public bool isDialogueActive = false;

    private DialogueSO currentDialogue;
    private int dialogueIndex;
    public Animator animator;

    void Start()
    {

        if (Instance == null)
            Instance = this;

    }

    public void StartDialogue(DialogueSO dialogueSO)
    {
        currentDialogue = dialogueSO;
        dialogueIndex = 0;
        animator.Play("show");
        isDialogueActive = true;
        ShowDialogue();
    }
    public void AdvanceDialogue()
    {
        if (dialogueIndex < currentDialogue.lines.Length)
            ShowDialogue();
        else
            EndDialogue();
    }
    private void ShowDialogue()
    {
        DialogueLine line = currentDialogue.lines[dialogueIndex];

        portrait.sprite = line.speaker.portrait;
        actorName.text = line.speaker.actorName;

        dialogueText.text = line.text;

        dialogueIndex++;
    }

    public void EndDialogue()
    {
        dialogueIndex = 0;
        animator.Play("hide");
        isDialogueActive = false;
    }
}
