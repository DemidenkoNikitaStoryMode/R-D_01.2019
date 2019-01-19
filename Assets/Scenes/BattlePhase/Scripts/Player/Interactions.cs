using System;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [HideInInspector] public Action<InteractionType> callback;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy") callback(InteractionType.Enemy);
        if (coll.tag == "Energy")
        {
            callback(InteractionType.Energy);
            coll.gameObject.SetActive(false);
        }
        if (coll.tag == "BuildMaterial")
        {
            callback(InteractionType.BuildMaterial);
            coll.gameObject.SetActive(false);
        }
    }

}

public enum InteractionType { Enemy, Energy, BuildMaterial }