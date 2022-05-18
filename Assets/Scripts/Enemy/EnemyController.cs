using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Entity
{
    #region EXPOSED_FIELDS
    [SerializeField] private EnemyAI enemyAI = null;
    [SerializeField] private Transform targetPlayer = null;
    #endregion

    #region UNITY_CALLS
    private void Update()
    {

    }
    #endregion

    #region INITIALIZATION
    public override void Init()
    {
        base.Init();

        enemyAI.Init(targetPlayer);
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
