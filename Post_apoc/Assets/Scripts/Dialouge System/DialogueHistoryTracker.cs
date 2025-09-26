using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHistoryTracker : MonoBehaviour
{
    public static DialogueHistoryTracker Instance;
    private readonly List<ActorSO> spokenNpcs = new List<ActorSO>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RecordNpc(ActorSO actorSO)
    {
        spokenNpcs.Add(actorSO);

        Debug.Log("just spoke to" + actorSO.actorName);
    }

    public bool HasSpokenWith(ActorSO actorSo)
    {
        return spokenNpcs.Contains(actorSo);
    }
}
