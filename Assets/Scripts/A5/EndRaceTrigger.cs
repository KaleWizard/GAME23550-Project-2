using NodeCanvas.Framework;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EndRaceTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject.TryGetComponent<Blackboard>(out var bb))
        {
            bb.SetVariableValue("raceFinished", true);
        }
    }
}
