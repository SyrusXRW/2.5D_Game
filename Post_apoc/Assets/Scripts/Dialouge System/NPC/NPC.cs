using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum NPCState { Default, Idle, Talk }
    public NPCState currentState = NPCState.Idle;
    private NPCState defaultState;
    public NPC_Interact talk;
    public NPC_Idle idle;



  // Start is called before the first frame update
    void Start()
    {
        defaultState = currentState;
        SwitchState(currentState);
    }

    public void SwitchState(NPCState newState)
    {
        currentState = newState;

        idle.enabled = newState == NPCState.Idle;
        talk.enabled = newState == NPCState.Talk;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Switches");
        if (collision.CompareTag("Player"))
            SwitchState(NPCState.Talk);
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
            SwitchState(defaultState);
    }

    
}
