using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Gun")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 40f;
    [SerializeField] private float fireRate = 0.2f; //seconds between shots
    [SerializeField] private int bulletsPerShot = 1; //more than 1 for shotgun
    [SerializeField] private float spread = 0f; //0 is perfectly straight, 0.1 is a wide shotgun

    [Header("Ammo")]
    [SerializeField] private int magazineSize = 12;
    [SerializeField] private int ammo = 12;
    [SerializeField] private int reserveAmmo = 60;
    [SerializeField] private float reloadTime = 1.5f;

    private float fireTimer;
    private float reloadTimer;
    private bool reloading = false;

    private void Start()
    {
        ammo = magazineSize;
    }

    private void Update()
    {
        fireTimer -= Time.deltaTime;

        if (reloading)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                FinishReload();
            }
        }
    }

    public void Shoot()
    {
        if (reloading || fireTimer > 0)
        {
            return;
        }

        if (ammo <= 0)
        {
            StartReload(); 
            return;
        }

        for (int i = 0; i < bulletsPerShot; i++)
        {
            SpawnBullet();
        }

        ammo--;
        fireTimer = fireRate;
    }

    private void SpawnBullet()
    {
        Vector3 direction = firePoint.forward;
        direction += firePoint.right * Random.Range(-spread, spread);
        direction += firePoint.up * Random.Range(-spread, spread);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody bulletBody = bullet.GetComponent<Rigidbody>();
        bulletBody.linearVelocity = direction.normalized * bulletSpeed;
    }

    public void StartReload()
    {
        if (reloading || ammo == magazineSize || reserveAmmo <= 0)
        {
            return;
        }

        reloading = true;
        reloadTimer = reloadTime;
        Debug.Log("Reloading");
    }

    private void FinishReload()
    {
        int needed = magazineSize - ammo;

        if (needed > reserveAmmo)
        {
            needed = reserveAmmo;
        }

        ammo += needed;
        reserveAmmo -= needed;
        reloading = false;
    }

    public void AddAmmo(int amount)
    {
        reserveAmmo += amount;
    }
}