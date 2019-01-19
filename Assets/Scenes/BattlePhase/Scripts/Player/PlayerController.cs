using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Interactions interactions;
    [SerializeField] Movement movement;
    [SerializeField] View view;
    [Header("Player settings")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float speed;
    [SerializeField] float energy;
    [SerializeField] float disableTime;

    private bool isDead;

    private void Awake()
    {
        interactions.callback = Interact;
    }

    private void Update()
    {
        Move();
        View();
    }

    #region Interaction
    private void Interact(InteractionType type)
    {
        if (isDead) return;
        switch (type)
        {
            case InteractionType.Enemy: Kill(); break;
            case InteractionType.Energy: GetEnergy(); break;
            case InteractionType.BuildMaterial: GetMaterial(); break;
        }
    }

    private void Kill()
    {
        isDead = true;
        sprite.enabled = false;
        StartCoroutine(DoSmthAfterTime(Spawn, disableTime));
    }

    private void GetEnergy()
    {
        // get energy
        Debug.Log("enery");
    }

    private void GetMaterial()
    {
        // get material
        Debug.Log("material");
    }

    private IEnumerator DoSmthAfterTime(Action action, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        action.Invoke();
    }

    #endregion

    #region Movement
    private void Spawn()
    {
        movement.MoveTo(spawnPoint.position);
        view.MoveTo(spawnPoint.position);
        sprite.enabled = true;
        isDead = false;
    }

    private void Move()
    {
        if (isDead) return;
        movement.Move(speed);
    }

    #endregion

    #region View
    private void View()
    {
        view.MoveCamera();
    }
    #endregion


}
