using UnityEngine;
using UnityEngine.UI;

using System;

using TMPro;

public class PlayerUI : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private TextMeshProUGUI bulletsText = null;
    [SerializeField] private Image healthImage = null;
    #endregion

    #region PRIVATE_FIELDS

    #endregion

    #region PUBLIC_ACTIONS
    public Action<string> onShoot = null;
    #endregion

    #region UNITY_CALLS
    private void Update()
    {

    }
    #endregion

    #region INITIALIZATION
    public void Init()
    {
        this.onShoot = OnShoot;
    }
    #endregion

    #region PRIVATE_METHODS
    private void OnShoot(string amount)
    {
        bulletsText.text = amount;
    }
    #endregion
}
