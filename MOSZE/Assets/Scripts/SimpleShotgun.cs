using UnityEngine;

public class SimpleShotgun : MonoBehaviour
{
    public Transform barrelEnd;  // A fegyver cs� v�ge (ahonnan a l�v�s indul)
    public float range = 50f;    // L�v�s t�vols�ga
    public int damage = 10;      // Sebz�s
    public AudioClip shootSound; // Hang
    private AudioSource audioSource;
    public Camera playerCamera;  // A j�t�kos kamer�ja

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

        // A l�v�s ir�nya: a kamera el�re n�z� ir�nya (forward) figyelembe v�ve, hogy a kamera merre n�z
        Vector3 shootDirection = playerCamera.transform.forward;  // Teljesen a kamera el�re n�z� ir�ny

        // Raycast haszn�lata a l�v�s ir�ny�ban
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
}