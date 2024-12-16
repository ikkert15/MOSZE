using UnityEngine;
using UnityEngine.SceneManagement; 

public class EnemyFollow : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f; 
    public float followDistance = 10f; 
    public string gameOverSceneName = "GameOver"; 

    private float initialY; 

    void Start()
    {
        
        initialY = transform.position.y;
    }

    void Update()
    {
        if (player == null)
        {
            
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogWarning("nincs player a p�ly�n");  //debug iba eset�n
                return;
            }
        }

        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance)
        {
            
            Vector3 direction = (player.position - transform.position).normalized;

            
            direction.y = 0;

            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);

            
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;
            newPosition.y = initialY; 
            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Coin.ResetCoinCount(); //coi null�z�s hal�l eset�n
            SceneManager.LoadScene(8); //gameover scene bet�lt�s
        }
    }
}