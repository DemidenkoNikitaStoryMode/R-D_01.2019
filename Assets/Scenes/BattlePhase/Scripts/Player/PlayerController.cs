using System;
using System.Collections;
using UnityEngine;
using Assets.Scripts.ModelLoader;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Interactions interactions;
    [SerializeField] Movement movement;
    [SerializeField] View view;
    [Header("Player settings")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] SpriteRenderer sprite;

    private GameModel model;

    private bool isDead;

    private void Awake()
    {
        interactions.callback = Interact;
        model = new PlayerPrefsModelLoader().LoadGameModel();
    }

    private void Update()
    {
        Move();
        View();
        HotKeys();
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
        StartCoroutine(DoSmthAfterTime(Spawn, model.PlayerStats.RespawnTime));
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
        movement.Move(model.PlayerStats.Speed);
    }

    #endregion

    #region View
    private void View()
    {
        view.MoveCamera();
    }
    #endregion

    #region HotKey
    private void HotKeys()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            view.MoveTo(movement.GetPlayerPosition());
        }
    }
    #endregion

}
