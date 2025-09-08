using UnityEngine;
using UnityEngine.InputSystem;

public class NPC_Interact : MonoBehaviour
{
    private Rigidbody rb;
    public DialogueSO dialogueSO;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("DialogueCollecting");
            if (DialogueManager.Instance.isDialogueActive)
                DialogueManager.Instance.AdvanceDialogue();
            else
                Debug.Log("DialogueStarting");
                DialogueManager.Instance.StartDialogue(dialogueSO);
        }
    }
}
