using System.Collections.Generic;
using UnityEngine;

public class HurdleRaceCamera : MonoBehaviour
{
    [SerializeField] List<Transform> toFollow;

    Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = AveragePosition() - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = AveragePosition() - offset;
    }

    Vector3 AveragePosition()
    {
        Vector3 total = Vector3.zero;
        foreach (Transform t in toFollow)
        {
            total += t.position;
        }
        return total / toFollow.Count;
    }
}
