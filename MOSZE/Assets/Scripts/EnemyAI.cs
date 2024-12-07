using UnityEngine;
using UnityEngine.SceneManagement; // A GameOver jelenet bet�lt�s�hez

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // A Player referenci�ja
    public float speed = 3f; // Az Enemy sebess�ge
    public float followDistance = 10f; // Maxim�lis t�vols�g, ameddig k�veti a Playert
    public string gameOverSceneName = "GameOver"; // A Game Over jelenet neve

    private float initialY; // Az Enemy kezdeti magass�ga

    void Start()
    {
        // Mentj�k az Enemy kezdeti magass�g�t
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

        // Ellen�rizd a t�vols�got a Playert�l
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance)
        {
            // Ford�tsd az Enemy-t a Player fel�
            Vector3 direction = (player.position - transform.position).normalized;

            // Csak az X �s Z tengely mozg�s�t enged�lyezz�k
            direction.y = 0;

            // Friss�tsd az Enemy rot�ci�j�t a Player fel�
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);

            // Friss�ts�k az Enemy poz�ci�j�t, de hagyjuk meg az eredeti Y �rt�ket
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
            newPosition.y = initialY; // Y-tengely r�gz�t�se
            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ha az Enemy hozz��r a Playerhez, Game Over
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}