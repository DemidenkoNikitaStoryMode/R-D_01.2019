using System;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [HideInInspector] public Action<InteractionType> callback;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy") callback(InteractionType.Enemy);
        if (collision.collider.tag == "Energy") callback(InteractionType.Energy);
        if (collision.collider.tag == "BuildMaterial") callback(InteractionType.BuildMaterial);
    }

}

public enum InteractionType { Enemy, Energy, BuildMaterial }