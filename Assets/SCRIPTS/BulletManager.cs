using UnityEngine;

public class BulletManager : MonoBehaviour
{
    
    [Header("BULLET'S ATRIBUTES")]
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
        if (PlayerBullet) Destroy(gameObject, 1.5f); // ALLY BULLETS DISSAPEAR
        
        else Destroy(gameObject, 5); // ENEMY BULLETS DISSAPEAR
    }

    public void OnTriggerEnter2D(Collider2D collided)
    {
        if(PlayerBullet && collided.gameObject.CompareTag("Enemy") || collided.gameObject.CompareTag("Shield"))
        { // IS ALLY BULLET AND TOUCHES AND ENEMY OR A WALL
            Destroy(collided.gameObject);
            Destroy(gameObject);
        }
        else if(!PlayerBullet && collided.gameObject.CompareTag("Shield") )
        { // IS ENEMY BULLETS AND TOUCHES THE SHIELDS
           
            Destroy(collided.gameObject);
            Destroy(gameObject);
        }
        // PLAYER LOOSING CONDITION IN PLAYER SCRIPT

    }




}
