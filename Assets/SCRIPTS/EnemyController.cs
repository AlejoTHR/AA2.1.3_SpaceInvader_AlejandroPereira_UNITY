using System;
using Unity.VisualScripting;
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
    public int TIMER;

    private GameObject Children;


    private void FixedUpdate()
    {
        Mover= new Vector3(Direction, DownDirection);
        // EVERY ENEMY LINE
        if (time % TIMER == 2f)
            transform.position += Mover;
        time++;
        /* IDEA
        for (int i = 0; i < Children.transform.childCount; i++)
        {
            GameObject child = Children.transform.GetChild(i).gameObject;
        }
        */

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
