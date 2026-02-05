using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Tooltip("PLAYER'S RIGIDBODY2D")]
    public Rigidbody2D rb;
    [Tooltip("DIRECTION VECTOR")]
    public Vector2 Direction;
    [Tooltip("MOVEMENT SPEED'S VALUE")]
    public int Speed;
    
    // CUSTOM FUNCTION | READS PLAYER INPUT THROUGH UNITY'S INPUT SYSTEM
    public void OnMove(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        Vector3 move = new Vector3(Direction.x*Speed, transform.position.y, transform.position.z);
        rb.linearVelocity = move;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {


    }

}
