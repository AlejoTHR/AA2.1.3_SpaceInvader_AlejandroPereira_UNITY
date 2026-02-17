using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Tooltip("PLAYER'S RIGIDBODY2D")]
    public Rigidbody2D rb;
    [Tooltip("DIRECTION VECTOR")]
    public Vector2 Direction;
    [Tooltip("MOVEMENT SPEED'S VALUE")]
    public int Speed;
    public int BulletOffsetSpanw;
    [Tooltip("AMMO GameObject")]
    public GameObject bullet;
    
    // CUSTOM FUNCTION | READS PLAYER INPUT THROUGH UNITY'S INPUT SYSTEM

    private void Update()
    {
        // MOVEMENT VECTOR that affects RB of the player
        Vector3 move = new Vector3(Direction.x*Speed, transform.position.y, transform.position.z);
        rb.linearVelocity = move;
    }

    public void OnMove(InputAction.CallbackContext context)
    {// PICKS THE DIRECTION
        Direction = context.ReadValue<Vector2>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {// ATTACKS
        Vector3 OriginPosition = new Vector3(transform.position.x, transform.position.y + BulletOffsetSpanw);
        GameObject newBullet = Instantiate(bullet, OriginPosition, transform.rotation);

    }

}
