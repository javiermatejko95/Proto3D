using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private PlayerController playerController = null;
    [SerializeField] private EnemyController enemyController = null;
    #endregion

    #region UNITY_CALLS
    private void Start()
    {
        playerController.Init();
        enemyController.Init();
    }
    #endregion
}
