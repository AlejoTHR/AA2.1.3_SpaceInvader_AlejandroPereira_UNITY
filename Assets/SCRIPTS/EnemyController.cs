using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Android;

public class EnemyController : MonoBehaviour
{
    public float Direction;
    public float DownDirection;
    public Vector3 Mover;
    public GameObject Wall;
    public int time;
    public short enemyline;

    private void FixedUpdate()
    {
        // Time meter
        time++;
        Mover= new Vector3(Direction, DownDirection);
        // EVERY ENEMY LINE
        if (enemyline == 1 && time % 10 == 0)
            transform.position += Mover;

        else if (enemyline == 2 && time % 10 == 0)
            transform.position += Mover;

        else if (enemyline == 3 && time % 10 == 0)
            transform.position += Mover;

        else if (enemyline == 4 && time % 10 == 0)
            transform.position += Mover;

        else if (enemyline == 5 && time % 10 == 0)
            transform.position += Mover;
    }

    private void OnTriggerEnter2D(Collider2D wall)
    {
        Wall = wall.gameObject;
        if (wall.gameObject.CompareTag("Wall"))
        {
            Direction *=-1;
            DownDirection -= 1;
        }

    }
    private void OnTriggerExit2D(Collider2D wall)
    {
        if (wall.gameObject.CompareTag("Wall"))
        {
            DownDirection = 0;
        }
    }
}
