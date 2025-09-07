using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour, IInteractable
{
     [SerializeField] private string _prompt;

     public Item item;

     public string InteractionPrompt => _prompt;

     public bool Interact(Interactor interactor)
     {
          PickUp();
          Debug.Log(message: "Debugged!");
          return true;
     }
     void PickUp()
     {
          Debug.Log("Picking up" + item.name);
          bool wasPickedUp = Inventory.instance.Add(item);

          if (wasPickedUp)
               Destroy(gameObject);
     }
}
