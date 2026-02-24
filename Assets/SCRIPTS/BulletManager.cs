using UnityEngine;

public class BulletManager : MonoBehaviour
{
    
    [Tooltip("BULLET'S SPEED")]
    private Rigidbody2D rb;
    public float Speed = 10;
    // CHANGED IN THE ISPECTOR TO MATCH ENEMY BULLETS
    public bool PlayerBullet = true;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (PlayerBullet) rb.AddForce(transform.up * Speed); // ALLY BULLETS UP
        else rb.AddForce((transform.up * -1) * Speed); // ENEMY BULLETS DOWN
    }

    private void FixedUpdate()
    {
        if (PlayerBullet) Destroy(gameObject, 1.5f); // LLY BULLETS DISSAPEAR
        
        else Destroy(gameObject, 5); // ENEMY BULLETS DISSAPEAR
    }

    public void OnTriggerEnter2D(Collider2D collided)
    {
        if(PlayerBullet && !collided.gameObject.CompareTag("Player") && !collided.gameObject.CompareTag("Wall_Left") && !collided.gameObject.CompareTag("Wall_Right") )
        { // IS ALLY BULLET AND DOESNT TOUCHES PLAYR NEITHER WALLS
            Destroy(collided.gameObject);
            Destroy(gameObject);
        }
        else if(!PlayerBullet && !collided.gameObject.CompareTag("Enemy") && !collided.gameObject.CompareTag("Wall_Left") && !collided.gameObject.CompareTag("Wall_Right"))
        { // IS ENEMY BULLETS AND DOEST TOUCHES ENEMY OR WALLS
           
            Destroy(collided.gameObject);
            Destroy(gameObject);
        }


    }
}
