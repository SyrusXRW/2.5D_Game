// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

namespace Yarn.Unity.Example
{
  public class Boat : MonoBehaviour, IInteractable
  {
    [SerializeField] private string _prompt;

    private InMemoryVariableStorage inMemoryVariableStorage;
    public PlayerController playerController;
    public string InteractionPrompt => _prompt;

    public Item item;

    public bool Interact(Interactor interactor)
    {
      foreach (Item item in interactor.GetComponent<PlayerController>().inventory)
        if (item.DockingPass == true)
        {
          SceneManager.LoadScene("BoatTest");
          Debug.Log(message: "Docking Boat!");
          return true;
        }
      return false;
    }
  }
}