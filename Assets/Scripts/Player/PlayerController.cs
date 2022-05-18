using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    #region EXPOSED_FIELDS
    [Header("Config")]
    [SerializeField] private CharacterController characterController = null;
    [Header("Components")]
    [SerializeField] private PlayerMovement playerMovement = null;
    [SerializeField] private PlayerUI playerUI = null;
    [SerializeField] private PlayerShoot playerShoot = null;
    [SerializeField] private MouseLook mouseLook = null;
    #endregion

    #region PRIVATE_FIELDS

    #endregion

    #region PUBLIC_ACTIONS

    #endregion

    #region UNITY_CALLS
    private void Update()
    {
        playerMovement.Move();
    }
    #endregion

    #region INITIALIZATION
    public override void Init()
    {
        base.Init();
        playerMovement.Init(characterController);
        playerUI.Init();
        playerShoot.Init(playerUI);
    }
    #endregion

    #region PRIVATE_METHODS

    #endregion
}
