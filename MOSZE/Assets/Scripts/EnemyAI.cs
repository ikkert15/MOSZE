using UnityEngine;
using UnityEngine.SceneManagement; // A GameOver jelenet betöltéséhez

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // A Player referenciája
    public float speed = 3f; // Az Enemy sebessége
    public float followDistance = 10f; // Maximális távolság, ameddig követi a Playert
    public string gameOverSceneName = "GameOver"; // A Game Over jelenet neve

    private float initialY; // Az Enemy kezdeti magassága

    void Start()
    {
        // Mentjük az Enemy kezdeti magasságát
        initialY = transform.position.y;
    }

    void Update()
    {
        if (player == null)
        {
            // Ha nincs megadva Player, automatikusan megkeresi
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogWarning("Player object not found in the scene!");
                return;
            }
        }

        // Ellenõrizd a távolságot a Playertõl
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance)
        {
            // Fordítsd az Enemy-t a Player felé
            Vector3 direction = (player.position - transform.position).normalized;

            // Csak az X és Z tengely mozgását engedélyezzük
            direction.y = 0;

            // Frissítsd az Enemy rotációját a Player felé
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);

            // Frissítsük az Enemy pozícióját, de hagyjuk meg az eredeti Y értéket
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
            newPosition.y = initialY; // Y-tengely rögzítése
            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ha az Enemy hozzáér a Playerhez, Game Over
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}