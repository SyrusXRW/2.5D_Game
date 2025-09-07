using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Robot : MonoBehaviour, IInteractable
{
     [SerializeField] private string _prompt;

     public Item item;

     public PlayerController playercontroller;

     public string InteractionPrompt => _prompt;

     public bool Interact(Interactor interactor)
     {
          PickUp();
          Debug.Log(message: "opening chest!");
          return true;
     }
     void PickUp()
     {
          playercontroller.Add(item);
          Debug.Log("Picking up" + item.name);
          Destroy(gameObject);
     }
}

