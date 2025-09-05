using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform InteractorSource; 
    [SerializeField] private LayerMask Interact;
    [SerializeField] private float InteracRange = 0.5f;
    [SerializeField] private InteractionPromptUi _interactionPromptUI;
    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;
    // Start is called before the first frame update
    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(InteractorSource.position, InteracRange, _colliders, (int)Interact);

        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame) _interactable.Interact(this);
            }

        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(InteractorSource.position, InteracRange);
    }
}
