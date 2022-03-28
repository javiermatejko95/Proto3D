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
    private string maxAmmo = string.Empty;
    #endregion

    #region PUBLIC_ACTIONS
    public Action<string, string> onUpdateAmmo = null;
    #endregion

    #region UNITY_CALLS
    private void Update()
    {

    }
    #endregion

    #region INITIALIZATION
    public void Init()
    {
        this.onUpdateAmmo = OnShoot;
    }
    #endregion

    #region PRIVATE_METHODS
    private void OnShoot(string currentAmmo, string maxAmmo)
    {
        if(!string.IsNullOrEmpty(maxAmmo))
        {
            this.maxAmmo = maxAmmo;
            bulletsText.text = currentAmmo + "/" + maxAmmo;
        }
        else
        {            
            bulletsText.text = currentAmmo + "/" + this.maxAmmo;
        }
    }
    #endregion
}
