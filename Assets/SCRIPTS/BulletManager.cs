using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody2D rb;
    [Tooltip("BULLET'S SPEED")]
    public float Speed = 10;
    // CHANGED IN THE ISPECTOR TO MATCH ENEMY BULLETS
    public string tagColisioned = "Destroy";
    public bool PlayerBullet = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (PlayerBullet) rb.AddForce(transform.up * Speed);
        else rb.AddForce((transform.up * -1) * Speed);
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 1.5f);
    }
    public void OnTriggerEnter2D(Collider2D collided)
    {
        // PLAYER BULLETS
        if (collided.gameObject.CompareTag(tagColisioned))
        {
            Destroy(collided.gameObject);
            Destroy(gameObject);
        }
        // ENEMY BULLETS
        else if(collided.gameObject.CompareTag(tagColisioned))
        {
            Destroy(collided.gameObject);
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
