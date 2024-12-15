using UnityEngine;

public class SimpleShotgun : MonoBehaviour
{
    public Transform barrelEnd;   // A fegyver csõ vége (ahonnan a lövés indul)
    public GameObject bulletPrefab; // A Golyó prefab (ezt húzd be az Inspectorban)
    public float bulletSpeed = 20f; // Golyó sebessége
    public float range = 50f;     // Lövés távolsága (csak Raycasthoz használjuk)
    public int damage = 10;       // Sebzés
    public AudioClip shootSound;  // Hang
    private AudioSource audioSource;
    public Camera playerCamera;   // A játékos kamerája

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Ha lenyomják a tûz gombot (pl. bal egér gomb)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Hang lejátszása
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // Golyó kilövése
        ShootBullet();

        // Raycast alapú találat ellenõrzése
        Vector3 shootDirection = playerCamera.transform.forward;  // Kamera elõre nézõ iránya
        RaycastHit hit;
        if (Physics.Raycast(barrelEnd.position, shootDirection, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name); // Találat logolása

            // Ha az objektumnak van Health komponense
            Health targetHealth = hit.collider.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(damage);
            }
        }
        else
        {
            Debug.Log("Missed!");
        }

        // Debug célokra: megjeleníthetjük a lövés irányát a Scene nézetben
        Debug.DrawRay(barrelEnd.position, shootDirection * range, Color.red, 1f);
    }

    void ShootBullet()
    {
        if (bulletPrefab != null)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, barrelEnd.position, barrelEnd.rotation);

            
            Vector3 shootDirection = playerCamera.transform.forward;  

            
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                
                rb.useGravity = false;


                rb.velocity = shootDirection * bulletSpeed;
            }

            
            Destroy(bullet, 3f); 
        }
    }
}