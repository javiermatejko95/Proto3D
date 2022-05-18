using UnityEngine;

[CreateAssetMenu(fileName = "Gun_", menuName = "Entity/Gun", order = 0)]
public class Gun : ScriptableObject
{
    #region EXPOSED_FIELDS
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private float range = 100f;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private GameObject gunPrefab = null;
    #endregion

    #region PROPERTIES
    public int MaxAmmo { get => maxAmmo; }
    public float Range { get => range; }
    public int DamageAmount { get => damageAmount; }
    public GameObject GunPrefab { get => gunPrefab; }
    #endregion
}
