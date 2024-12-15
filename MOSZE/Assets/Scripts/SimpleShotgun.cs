using UnityEngine;

public class SimpleShotgun : MonoBehaviour
{
    public Transform barrelEnd;   
    public GameObject bulletPrefab; 
    public float bulletSpeed = 20f; 
    public float range = 50f;     
    public int damage = 10;       
    public AudioClip shootSound;  
    private AudioSource audioSource;
    public Camera playerCamera;   

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  
        {
            Fire();
        }
    }

    void Fire()
    {
        
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }

        
        ShootBullet();

        
        Vector3 shootDirection = playerCamera.transform.forward;  
        RaycastHit hit;
        if (Physics.Raycast(barrelEnd.position, shootDirection, out hit, range))
        {
            Debug.Log("Hit: " + hit.collider.name); 

            
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