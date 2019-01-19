using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{
    public GameObject Energy;
    public GameObject BuildMaterial;
    public Collider2D Tower;
    public Vector2 MinPoint;
    public Vector2 MaxPoint;
    public float Distance;
    public int EnergyQuantity;
    public int BuildMaterialQuantity;
    private Vector2 spawnPoint;

    void Start()
    {
        SpawnItems(EnergyQuantity, BuildMaterialQuantity);
    }


    void Update()
    {
        
    }

    public void SpawnItems(int EnergyQuatity, int BuildMateialQuatity)
    {
        List<Vector2> spawnedList = new List<Vector2>();

        float randX;
        float randY;
        int i=0;
        while (i < EnergyQuantity)
        {
            randX = Random.Range(MinPoint.x, MaxPoint.x);
            randY = Random.Range(MinPoint.y, MaxPoint.y);
            spawnPoint = new Vector2(randX, randY);
            if (spawnedList.All(IsInRange))
            {
                spawnedList.Add(spawnPoint);
                Instantiate(Energy, spawnPoint, Quaternion.identity);
                i++;
            }
        }
        i = 0;
        while (i < BuildMaterialQuantity)
        {
            randX = Random.Range(MinPoint.x, MaxPoint.x);
            randY = Random.Range(MinPoint.y, MaxPoint.y);
            spawnPoint = new Vector2(randX, randY);
            if (spawnedList.All(IsInRange))
            {
                spawnedList.Add(spawnPoint);
                Instantiate(BuildMaterial, spawnPoint, Quaternion.identity);
                i++;
            }
        }
    }

    private bool IsInRange(Vector2 s)
    {
        return Vector2.Distance(s, spawnPoint) >= Distance && !Tower.bounds.Contains(spawnPoint);
    }
}
