using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [Header("ARMY MANAGER")]
    public ARMYmanager Army_Manager;
    

    [Header("VALUE")]
    public int VALUE;

    void Awake()
    {// GETS ALIEN GAME OBJECT
        Army_Manager.aliens_army.Add(this);
    }

    private void OnDisable()
    {// REMOVES ALIEN GAME OBJECT
        AliensDeath();
    }

    private void OnTriggerEnter2D(Collider2D Collided)
    {
        if(Collided.gameObject.CompareTag("Wall_Right") && Army_Manager._goingRight)
        { // IF INDIVIDUAL ALIEN COLLIDED WITH RIGHT WALL AND IS GOING RIGHT
            Army_Manager.ChangeDirection();
        }
        else if (Collided.gameObject.CompareTag("Wall_Left") && !Army_Manager._goingRight)
        { // IF INDIVIDUAL ALIEN COLLIDED WITH LEFT WALL AND IS NOT GOING RIGHT
            Army_Manager.ChangeDirection();
        }
        else if(Collided.gameObject.CompareTag("Shield"))
        { // ALIENS DESTROY SHIELDS
            Destroy(Collided.gameObject);
        }

    }

    public void AliensDeath()
    {
        Army_Manager.aliens_army.Remove(this); // ALIENS LIST GETS DOWN 1
        Army_Manager.Accelerate(); // SEE ARMY MANAGER
        Army_Manager.ARMY_SCORE += VALUE; // ADDS ALIEN VALUE TO SCORE | SEE UI_MANAGER
    }




}
