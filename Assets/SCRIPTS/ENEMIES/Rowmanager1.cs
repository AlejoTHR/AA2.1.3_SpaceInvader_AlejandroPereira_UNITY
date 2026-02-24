using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Rowmanager1 : MonoBehaviour
{
    [Header("GAME MANAGER")]
    public GAME_MANAGER gameManager;


    [Header("Changing Direction")]
    public int Direction;

    [Header("COUNTERS (COUNT HAS DELAY BELOW 0)")]
    public float COUNT;
    public float COUNTmax;

    private void FixedUpdate()
    {
        RowMovement();
    }

    public void RowMovement()
    {
        COUNT += Time.deltaTime; // COUNTS TIME IN DELTA_TIME
        if (COUNT >= COUNTmax)
        {
            transform.position += Vector3.right * Direction; // MOVES THE WHOLE ROW
            COUNT = 0; // RESTARTS TIMER
        }
    }

    private void OnTriggerEnter(Collider collided)
    {
     if(collided.gameObject.CompareTag("GAMEOVER"))
        {
            gameManager.GAMEOVER();
        }
        
    }


}
