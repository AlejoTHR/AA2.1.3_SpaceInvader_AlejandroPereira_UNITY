using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("GAME:MANAAGER")]
    public GameManager GAME_manager;

    [Header("PLAYER'S ATRIBUTES")]
    public Rigidbody2D rb;
    public SpriteRenderer SprtRenderer;
    public Collider2D cllder;
    public PlayerInput plyrInpyt;

    [Header("DIRECTION VECTOR")]
    public Vector2 Direction;
    public Vector3 Origin;
    public int ORIGINy = -9;

    [Header("MOVEMENT SPEED'S VALUE")]
    public int Speed;
    public int BulletOffsetSpanw;
    
    [Header("AMMO GameObject")]
    public GameObject bullet;
    public BulletManager Bullet_Manager;

    private void Awake()
    {
        // INITIALIZE PLAYER COMPONENTS 
        plyrInpyt = GetComponent<PlayerInput>();
        SprtRenderer = GetComponent<SpriteRenderer>();
        cllder = GetComponent<Collider2D>();

        // INITIALIZE ORIGIN VECTOR FOR LATER
        Origin = new Vector3(0, ORIGINy);
    }
    private void FixedUpdate()
    {
        // MOVEMENT VECTOR, X AIS DEPENDES ON DIRECTION
        Vector3 move = new Vector3(Direction.x*Speed, transform.position.y, transform.position.z);

        // RB MOVES AS VECTOR 3 MOVES
        rb.linearVelocity = move;
    }

    public void OnMove(InputAction.CallbackContext context)
    {// PICKS THE DIRECTION BASED ON ACTION CONTEXT FROM UNITY ACTION SYSTEM (A/D IN THIS CASE)
        Direction = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {// IF SPACE OR CLICK BASED ON ACTION CONTEXT FROM UNITY ACTION SYSTEM
        if(context.performed)
        {
            // BULLET ORIGIN POSITION
            Vector3 BulletOriginPosition = new Vector3(transform.position.x, transform.position.y + BulletOffsetSpanw);
            // CREATES GAME OBJECT BULLET WITH PREFAB AND ORIGIN VECTOR
            GameObject newBullet = Instantiate(bullet, BulletOriginPosition, transform.rotation);
        }
    }


    private void OnTriggerEnter2D(Collider2D collided)
    {
        if(collided.gameObject.CompareTag("Bullet")) // IF IS TOUCHED BY ENEMY BULLET
        {
            transform.position = Origin; // MOVES THE PLAYER TO ORIGIN POSITION

            GAME_manager.PlayerHurt(); // SEE GAME MNAGER

            GAME_manager.StartCoroutine(GAME_manager.PlayerhurtBlink()); // SEE GAME MANAGER (MAAGES BLINK TIME WHEN HIT)
        }



    }

}
