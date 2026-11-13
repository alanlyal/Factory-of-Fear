using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private Weapon currentWeapon; //the weapon the player is holding
    [SerializeField] private Transform weaponHolder; //where a new weapon gets placed

    [Header("Input Actions")]
    [SerializeField] private InputActionReference shootAction;
    [SerializeField] private InputActionReference reloadAction;

    private void OnEnable()
    {
        shootAction.action.Enable();
        reloadAction.action.Enable();
    }

    private void OnDisable()
    {
        shootAction.action.Disable();
        reloadAction.action.Disable();
    }

    private void Update()
    {
        if (currentWeapon == null)
        {
            return;
        }

        if (reloadAction.action.WasPressedThisFrame())
        {
            currentWeapon.StartReload();
        }

        if (shootAction.action.IsPressed())
        {
            currentWeapon.Shoot();
        }
    }

    //when we add new weapons we cna use this to replace held one.
    public void SwapWeapon(GameObject weaponPrefab)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject); //remove the old weapon
        }

        GameObject newWeapon = Instantiate(weaponPrefab, weaponHolder);
        currentWeapon = newWeapon.GetComponent<Weapon>();
    }
}