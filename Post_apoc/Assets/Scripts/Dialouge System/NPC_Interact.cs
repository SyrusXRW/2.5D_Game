using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interact : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

     public string InteractionPrompt => _prompt;

    public DialogueSO dialogueSO;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogueSO);
    }

    public bool Interact(Interactor interactor)
    {
        TriggerDialogue();
        if (DialogueManager.Instance.isDialogueActive)
            DialogueManager.Instance.AdvanceDialogue();
        return true;
        
    }

}
