using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{
    public GameObject player;  
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = player.transform.position;  
    }
    void Update()
    {
        if (player.transform.position.x > initialPosition.x)
        {
            Debug.Log("Test Passed: Player moved.");
        }
        else
        {
            Debug.Log("Test Failed: Player did not move.");
        }
    }
}
