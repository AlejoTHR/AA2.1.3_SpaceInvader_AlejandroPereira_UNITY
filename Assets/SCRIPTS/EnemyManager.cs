using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Aliens Movement")]
    public Vector3 Move;

    private int COUNT;
    public int COUNTmax;
    public int Delay;

    [Header("Aliens in List")]
    public List<EnemyController> aliens;

    private void Start()
    {
        Move.x = 1;
        Move.y = 0;
        COUNT -= Delay;
    }

    private void FixedUpdate()
    {
        COUNT++;
        if (COUNT > COUNTmax)
        {
            transform.position += Move;
            Debug.Log(Time.time);
            COUNT = 0;
        }
    }


}
