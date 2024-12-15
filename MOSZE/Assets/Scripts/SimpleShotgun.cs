using UnityEngine;

public class SimpleShotgun : MonoBehaviour
{
    public Transform barrelEnd;   // A fegyver cs� v�ge (ahonnan a l�v�s indul)
    public GameObject bulletPrefab; // A Goly� prefab (ezt h�zd be az Inspectorban)
    public float bulletSpeed = 20f; // Goly� sebess�ge
    public float range = 50f;     // L�v�s t�vols�ga (csak Raycasthoz haszn�ljuk)
    public int damage = 10;       // Sebz�s
    public AudioClip shootSound;  // Hang
    private AudioSource audioSource;
    public Camera playerCamera;   // A j�t�kos kamer�ja

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Ha lenyomj�k a t�z gombot (pl. bal eg�r gomb)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Hang lej�tsz�sa
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        // Goly� kil�v�se
        ShootBullet();

        // Raycast alap� tal�lat ellen�rz�se
        Vector3 shootDirection = playerCamera.transform.forward;  // Kamera el�re n�z� ir�nya
        RaycastHit hit;
        if (Physics.Raycast(barrelEnd.position, shootDirection, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name); // Tal�lat logol�sa

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

        // Debug c�lokra: megjelen�thetj�k a l�v�s ir�ny�t a Scene n�zetben
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