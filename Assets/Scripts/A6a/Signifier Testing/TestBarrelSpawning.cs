using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class TestBarrelSpawning : MonoBehaviour
{
    [SerializeField] TestThrownBarrel barrelPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BarrelSpawning());
    }

    IEnumerator BarrelSpawning()
    {
        while (true)
        {
            SpawnBarrel();
            yield return new WaitForSeconds(1.5f);
        }
    }

    void SpawnBarrel()
    {
        Vector3 target = ThrowableArea.GetRandomPoint();
        var barrel = Instantiate(barrelPrefab, transform.position, Quaternion.identity);

        barrel.Init(target, 1, 2, 1);
    }
}
