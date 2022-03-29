using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [Header("Config")]
    [SerializeField] private CharacterController characterController = null;
    [Header("Components")]
    [SerializeField] private PlayerMovement playerMovement = null;
    [SerializeField] private PlayerUI playerUI = null;
    [SerializeField] private PlayerShoot playerShoot = null;
    [SerializeField] private MouseLook mouseLook = null;
    [Header("Scriptable Objects")]
    [SerializeField] private Health playerHealth = null;
    [SerializeField] private Gun selectedGun = null;
    #endregion

    #region PRIVATE_FIELDS

    #endregion

    #region PUBLIC_ACTIONS

    #endregion

    #region UNITY_CALLS
    private void Start()
    {
        playerMovement.Init(characterController);
        playerUI.Init();
    }

    private void Update()
    {
        playerMovement.Move();
    }
    #endregion

    #region INITIALIZATION
    public void Init()
    {

    }
    #endregion

    #region PRIVATE_METHODS

    #endregion
}
