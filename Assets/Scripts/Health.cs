using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Health_", menuName = "Entity/Health", order = 0)]
public class Health : ScriptableObject
{
    #region EXPOSED_FIELDS
    [SerializeField] private int maxHealth = 100;
    #endregion

    #region PROPERTIES
    public int MaxHealth { get => maxHealth; }
    #endregion
}
