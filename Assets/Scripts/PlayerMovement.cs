using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 moveDirection;
    private GameLoopManager gameLoop;

    void Start()
    {
        // Cache reference to GameLoopManager
        gameLoop = FindObjectOfType<GameLoopManager>();
    }

    void Update()
    {
        // 🚫 Do not allow movement unless game is PLAYING
        if (gameLoop == null || gameLoop.currentState != GameLoopManager.GameState.Playing)
        {
            moveDirection = Vector2.zero;
            return;
        }

        // ===== INPUT =====
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontal, vertical);

        // ===== MOVEMENT =====
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}