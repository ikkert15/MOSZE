using UnityEngine;

public class SimpleShotgun : MonoBehaviour
{
    public Transform barrelEnd;  // A fegyver csõ vége (ahonnan a lövés indul)
    public float range = 50f;    // Lövés távolsága
    public int damage = 10;      // Sebzés
    public AudioClip shootSound; // Hang
    private AudioSource audioSource;
    public Camera playerCamera;  // A játékos kamerája

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

        // A lövés iránya: a kamera elõre nézõ iránya (forward) figyelembe véve, hogy a kamera merre néz
        Vector3 shootDirection = playerCamera.transform.forward;  // Teljesen a kamera elõre nézõ irány

        // Raycast használata a lövés irányában
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
}