using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{
    public GameObject Energy;
    public GameObject BuildMaterial;
    public GameObject Tower;
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
            randX = Random.Range(-8.9f, 8.9f);
            randY = Random.Range(-5f, 5f);
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
            randX = Random.Range(-8.9f, 8.9f);
            randY = Random.Range(-5f, 5f);
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
        return Vector2.Distance(s, spawnPoint) >= Distance && !Tower.GetComponent<Collider2D>().bounds.Contains(spawnPoint);
    }
}
