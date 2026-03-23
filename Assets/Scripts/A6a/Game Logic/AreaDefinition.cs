using UnityEngine;

public class AreaDefinition<T> : SingletonBehaviour<T> where T : AreaDefinition<T>
{
    // This class defines an area at height Y (overridable) and corners A and B

    protected virtual float Y => 0;

    [SerializeField] Vector2 cornerA = Vector3.zero;
    [SerializeField] Vector2 cornerB = Vector3.zero;

    Vector3 CornerA => new(cornerA.x, Y, cornerA.y);
    Vector3 CornerB => new(cornerB.x, Y, cornerB.y);

    public static Vector3 GetRandomPoint()
    {
        Vector3 point = new()
        {
            y = Instance.Y,
            x = Random.Range(Instance.cornerA.x, Instance.cornerB.x),
            z = Random.Range(Instance.cornerA.y, Instance.cornerB.y),
        };
        return point;
    }

    private void OnDrawGizmos()
    {
        Vector3 a = CornerA;
        Vector3 b = CornerB;
        Vector3 c = new(a.x, Y, b.z);
        Vector3 d = new(b.x, Y, a.z);

        Debug.DrawLine(a, c);
        Debug.DrawLine(b, d);
        Debug.DrawLine(c, b);
        Debug.DrawLine(d, a);
    }
}
