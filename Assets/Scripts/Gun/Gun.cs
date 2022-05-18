using UnityEngine;

public enum GUN_TYPE
{
    HANDGUN,
    RIFLE,
    SHOTGUN,
    KNIFE
}

[CreateAssetMenu(fileName = "Gun_", menuName = "Entity/Gun", order = 0)]
public class Gun : ScriptableObject
{
    #region EXPOSED_FIELDS
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private float range = 100f;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private GUN_TYPE GUNTYPE = default;
    [SerializeField] private GameObject gunPrefab = null;
    #endregion

    #region PROPERTIES
    public int MaxAmmo { get => maxAmmo; }
    public float Range { get => range; }
    public int DamageAmount { get => damageAmount; }
    public GUN_TYPE TYPE { get => GUNTYPE; }
    public GameObject GunPrefab { get => gunPrefab; }
    #endregion
}
