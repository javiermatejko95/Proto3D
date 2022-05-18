using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [Header("Scriptable Objects")]
    [SerializeField] protected Health health = null;
    #endregion

    #region PRIVATE_FIELDS
    protected int maxHealth = 0;
    protected int currentHealth = 0;
    #endregion

    #region PUBLIC_ACTIONS
    public Action<int> onDamaged = null;
    #endregion

    #region OVERRIDABLE_METHODS
    public virtual void Init()
    {
        maxHealth = health.MaxHealth;
        currentHealth = maxHealth;

        this.onDamaged += OnDamaged;
    }

    protected virtual void OnDamaged(int amount)
    {
        currentHealth -= amount;
    }
    #endregion
}
