using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Entity
{
    #region EXPOSED_FIELDS
    //[Header("Config")]
    //[Header("Components")]
    //[Header("Scriptable Objects")]
    #endregion

    #region PRIVATE_FIELDS

    #endregion

    #region PUBLIC_ACTIONS

    #endregion

    #region UNITY_CALLS
    private void Start()
    {
        this.Init();
    }

    private void Update()
    {

    }
    #endregion

    #region OVERRIDED_METHODS
    protected override void OnDamaged(int amount)
    {
        base.OnDamaged(amount);

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
