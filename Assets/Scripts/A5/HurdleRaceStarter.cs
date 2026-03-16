using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HurdleRaceStarter : MonoBehaviour
{
    [SerializeField] List<BehaviourTreeOwner> BTOwners;
    [SerializeField] List<GameObject> toDisableOnStart;
    
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            foreach (var BTOwner in BTOwners)
                BTOwner.graph.blackboard.SetVariableValue("raceStarted", true);

            foreach (var go in toDisableOnStart)
                go.SetActive(false);
        }
    }
}
