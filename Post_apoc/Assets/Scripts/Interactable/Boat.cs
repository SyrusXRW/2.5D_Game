using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boat : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

   public string InteractionPrompt => _prompt;

  public bool Interact(Interactor interactor)
  {
    if (inventory.item)
    {
      SceneManager.LoadScene("BoatTest");
      Debug.Log(message: "Docking Boat!");
      return true;
    }
    else
    {
      Debug.Log("erm");
      return true;
    }
   }
}
