using System.Collections.Generic;
using UnityEngine;

public class RowManager : MonoBehaviour
{
    public ARMYmanager ARMY_manager;

    [Header("Aliens Movement")]
    public Vector3 Move;

    public int COUNT;
    public int COUNTmax;
    public int Delay;

    [Header("Aliens in List")]
    public List<EnemyMovement> aliens;

    private void Start()
    {

        Move = new Vector3(1, 0);
        COUNT -= Delay;
    }

    private void FixedUpdate()
    {
        COUNT++;
        if (COUNT > COUNTmax)
        {
            transform.position += Move;
            COUNT = 0;
        }
    }


}
