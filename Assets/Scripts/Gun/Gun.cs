using UnityEngine;

[CreateAssetMenu(fileName = "Gun_", menuName = "Gun/Handgun", order = 0)]
public class Gun : ScriptableObject
{
    #region EXPOSED_FIELDS
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int currentAmmo = 10;
    [SerializeField] private GameObject gunPrefab = null;
    #endregion

    #region PROPERTIES
    public int MaxAmmo { get => maxAmmo; }
    public int CurrentAmmo { get => currentAmmo; }
    public GameObject GunPrefab { get => gunPrefab; }
    #endregion
}
