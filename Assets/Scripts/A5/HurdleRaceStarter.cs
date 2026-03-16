using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HurdleRaceStarter : MonoBehaviour
{
    [SerializeField] List<BehaviourTreeOwner> BTOwners;
    
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            foreach (var BTOwner in BTOwners)
                BTOwner.graph.blackboard.SetVariableValue("raceStarted", true);
        }
    }
}
