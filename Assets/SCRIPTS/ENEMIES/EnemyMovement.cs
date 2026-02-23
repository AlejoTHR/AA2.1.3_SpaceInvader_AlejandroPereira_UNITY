using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{

    [Header("DEBUG WALL COLLIDED DETECTED")]
    public GameObject WALL;


    [Header("ROW MANAGER")]
    public RowManager Row_Manager;
    [Header("ARMY MANAGER")]
    public ARMYmanager Army_Manager;
    


    [Header("TIMERS")]
    public bool WALLED = false;

    void Start()
    {// GETS ALIEN GAME OBJECT
        Row_Manager.aliens.Add(this);
        Army_Manager.aliens_army.Add(this);

    }

    private void OnDisable()
    {// REMOVES ALIEN GAME OBJECT
        Row_Manager.aliens.Remove(this);
        Army_Manager.aliens_army.Remove(this);
    }

    private void OnTriggerEnter2D(Collider2D wall)
    {
        WALL = wall.gameObject;

        if(wall.gameObject.CompareTag("Wall"))
        {
            WALLED = true;

        }
        else WALLED = false;


    }



}
