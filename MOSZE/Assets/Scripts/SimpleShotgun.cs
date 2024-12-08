using UnityEngine;

public class SimpleShotgun : MonoBehaviour
{
    public Transform barrelEnd;  
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
}