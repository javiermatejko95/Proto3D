using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Camera shootingCamera = null;

    //testing values
    [SerializeField] private float range = 100f;
    #endregion

    #region PRIVATE_FIELDS

    #endregion

    #region UNITY_CALLS
    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    #endregion

    #region INITIALIZATION

    #endregion

    #region PRIVATE_METHODS
    private void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(shootingCamera.transform.position, shootingCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
    #endregion
}
