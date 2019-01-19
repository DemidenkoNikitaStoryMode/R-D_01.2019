using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Interactions interactions;
    [SerializeField] Movement movement;
    [SerializeField] View view;
    [Header("Player settings")]
    [SerializeField] float speed;

    private void Awake()
    {
        interactions.callback = Interact;
    }

    private void Update()
    {
        movement.Move(speed);
        view.MoveCamera();
    }


    #region Interaction
    private void Interact(InteractionType type)
    {
        switch (type)
        {
            case InteractionType.Enemy: break;
            case InteractionType.Energy: break;
            case InteractionType.BuildMaterial: break;
        }
    }

    #endregion

    #region Movement

    #endregion

    #region View

    #endregion

}
