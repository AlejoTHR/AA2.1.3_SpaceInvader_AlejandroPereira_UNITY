using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("GAME:MANAAGER")]
    public GAME_MANAGER GAME_manager;

    [Tooltip("PLAYER'S RIGIDBODY2D")]
    public Rigidbody2D rb;
    
    [Tooltip("DIRECTION VECTOR")]
    public Vector2 Direction;
    
    [Tooltip("MOVEMENT SPEED'S VALUE")]
    public int Speed;
    public int BulletOffsetSpanw;
    
    [Tooltip("AMMO GameObject")]
    public GameObject bullet;

    private void FixedUpdate()
    {
        // MOVEMENT VECTOR that affects RB of the player
        Vector3 move = new Vector3(Direction.x*Speed, transform.position.y, transform.position.z);
        rb.linearVelocity = move;
    }

    private void OnDisable()
    {
        gameObject.SetActive(true);
        Vector3 Origin = new Vector3(0, -9);
        transform.position = Origin;
        GAME_manager.PlayerHurt();
    }


    public void OnMove(InputAction.CallbackContext context)
    {// PICKS THE DIRECTION
        Direction = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {// ATTACKS
        if(context.performed)
        {
            Vector3 OriginPosition = new Vector3(transform.position.x, transform.position.y + BulletOffsetSpanw);
            GameObject newBullet = Instantiate(bullet, OriginPosition, transform.rotation);
        }
    }

}
