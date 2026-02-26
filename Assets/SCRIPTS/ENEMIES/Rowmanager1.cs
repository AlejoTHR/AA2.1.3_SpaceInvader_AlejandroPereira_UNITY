using UnityEngine;

public class Rowmanager1 : MonoBehaviour
{
    [Header("GAME MANAGER")]
    public GameManager Game_Manager;

    [Header("ArmyManager")]
    public ARMYmanager AMY_manager;
    
    [Header("Changing Direction")]
    public int Direction;

    [Header("COUNTERS (COUNT HAS DELAY BELOW 0)")]
    public float COUNT;
    public float COUNTmax;

    private void FixedUpdate()
    {
        RowMovement(); // SEE FUNCTION
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


}
