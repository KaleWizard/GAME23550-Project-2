using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingBarrelManager : SingletonBehaviour<TestingBarrelManager>
{
    public List<GameObject> barrels = new();

    [SerializeField] GameObject barrelPrefab;

    public GameObject GetBarrel(Vector3 position)
    {
        if (barrels.Count == 0) return null;

        GameObject best = barrels[0];
        float dist = Vector3.Distance(position, best.transform.position);
        
        for (int i = 1; i < barrels.Count; i++)
        {
            float newDist = Vector3.Distance(position, barrels[i].transform.position);
            if (newDist < dist)
            {
                best = barrels[i];
                dist = newDist;
            }
        }
        barrels.Remove(best);
        return best;
    }

    void Start()
    {
        StartCoroutine(BarrelSpawning());
    }

    IEnumerator BarrelSpawning()
    {
        while (true)
        {
            while (barrels.Count >= 10) yield return null;
            Vector3 position = TestingBarrelSpawnArea.GetRandomPoint();
            barrels.Add(Instantiate(barrelPrefab, position, Quaternion.identity));
            yield return new WaitForSeconds(1.5f);
        }
    }
}
