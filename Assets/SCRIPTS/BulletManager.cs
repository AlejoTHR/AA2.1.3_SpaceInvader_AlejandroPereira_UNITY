using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody2D rb;
    [Tooltip("BULLET'S SPEED")]
    public float Speed = 10;
    // CHANGED IN THE ISPECTOR TO MATCH ENEMY BULLETS
    public bool PlayerBullet = true;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (PlayerBullet) rb.AddForce(transform.up * Speed);
        else rb.AddForce((transform.up * -1) * Speed);
    }

    private void FixedUpdate()
    {
        if (CompareTag("Bullet"))
        {
            Destroy(gameObject, 1.5f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collided)
    {
        Destroy(collided.gameObject);
        Destroy(gameObject);

    }
}
