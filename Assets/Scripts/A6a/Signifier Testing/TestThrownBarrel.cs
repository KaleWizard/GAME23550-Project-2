using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TestThrownBarrel : MonoBehaviour
{
    [SerializeField] LineRenderer travelLine;
    [SerializeField] LineRenderer impactLine;
    [Space]
    [SerializeField] AnimationCurve heightCurve;
    [Space]
    [SerializeField] GameObject explosionPrefab;

    Vector3 origin;
    Vector3 target;

    float heightIncrease;

    float timeToTarget;
    float progress = 0;

    float radius;

    int fidelity = 32;

    public void Init(Vector3 target, float radius, float heightIncrease, float time)
    {
        this.target = target;
        this.timeToTarget = time;
        this.origin = transform.position;
        this.heightIncrease = heightIncrease;
        this.radius = radius;

        travelLine.positionCount = fidelity + 1;
        impactLine.positionCount = fidelity;

        UpdateImpactLine();
    }

    void Update()
    {
        UpdatePosition();
        UpdateTravelLine();

        if (progress > timeToTarget)
        {
            OnImpact();
            Destroy(gameObject, 0.1f);
        }
    }

    void UpdatePosition()
    {
        progress += Time.deltaTime;

        Vector3 newPos = Vector3.Lerp(origin, target, progress / timeToTarget);
        newPos += heightCurve.Evaluate(progress / timeToTarget) * heightIncrease * Vector3.up;

        transform.position = newPos;
    }

    void UpdateTravelLine()
    {
        Vector3[] points = new Vector3[fidelity + 1];

        for (int i = 0; i <= fidelity; i++)
        {
            float progress = (this.progress + (timeToTarget - this.progress) * (i / (float) fidelity)) / timeToTarget;
            Vector3 point = Vector3.Lerp(origin, target, progress);
            point += heightCurve.Evaluate(progress) * heightIncrease * Vector3.up;

            points[i] = point;
        }
        travelLine.SetPositions(points);
    }

    void UpdateImpactLine()
    {
        Vector3[] points = new Vector3[fidelity];
        for (int i = 0; i < fidelity; i++)
        {
            points[i] = new()
            {
                y = target.y,
                x = target.x + radius * Mathf.Sin(Mathf.PI * 2 * (i / (float) fidelity)),
                z = target.z + radius * Mathf.Cos(Mathf.PI * 2 * (i / (float) fidelity)),
            };
        }
        impactLine.SetPositions(points);
    }

    void OnImpact()
    {
        if (explosionPrefab != null)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
