using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Camera shootingCamera = null;

    //testing values
    [SerializeField] private Gun gun = null;
    #endregion

    #region PRIVATE_FIELDS
    private PlayerUI playerUI = null;
    private int currentAmmo = 0;
    private int maxAmmo = 0;
    #endregion

    #region UNITY_CALLS
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    #endregion

    #region INITIALIZATION
    public void Init(PlayerUI playerUI)
    {
        this.playerUI = playerUI;
        maxAmmo = gun.MaxAmmo;
        currentAmmo = maxAmmo;
        playerUI.onUpdateAmmo?.Invoke(currentAmmo.ToString(), maxAmmo.ToString());
    }
    #endregion

    #region PRIVATE_METHODS
    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(shootingCamera.transform.position, shootingCamera.transform.forward, out hit, gun.Range))
        {
            currentAmmo--;
            playerUI.onUpdateAmmo?.Invoke(currentAmmo.ToString(), null);

            switch(hit.transform.tag)
            {
                case "Enemy":
                    EnemyController enemyController = hit.transform.GetComponent<EnemyController>();
                    enemyController.onDamaged?.Invoke(gun.DamageAmount);
                    break;
            }        
            Debug.Log(hit.transform.name);
        }

        Reload();
    }

    private void Reload()
    {
        if (currentAmmo <= 0)
        {
            currentAmmo = maxAmmo;
            playerUI.onUpdateAmmo?.Invoke(currentAmmo.ToString(), null);
        }
    }
    #endregion
}