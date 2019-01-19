using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static Tower Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Ouch! " + damage + " damage");
    }
}
