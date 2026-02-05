using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Rigidbody2D rb;
    [Tooltip("BULLET'S SPEED")]
    public float Speed = 10;
    [Tooltip("OBJECT TAG FOR DETECTION")]
    public string tagColisioned = "Destroy";



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collided)
    {
        if(collided.gameObject.tag == tagColisioned)
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
