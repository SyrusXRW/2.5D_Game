// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boat : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

  public Item item;
  public string InteractionPrompt => _prompt;

  public bool Interact(Interactor interactor)
  {
    var Inventory = interactor.GetComponent<Inventory>();

    if (Inventory == null) return false;

    foreach (Item item in Inventory.items(item))
    {
      if (items.add == items.Scrap)
      {
        SceneManager.LoadScene("BoatTest");
        Debug.Log(message: "Docking Boat!");
        return true;
      }
      else
      {
        Debug.Log("NoObject");
        return true;
      }
    }
  }
}
