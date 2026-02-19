using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyManager Enemy_Manager;
    public GameObject WALL;

    void Start()
    {// GETS ALIEN GAME OBJECT
        Enemy_Manager.aliens.Add(this);
    }
    private void OnDisable()
    {// REMOVES ALIEN GAME OBJECT
        Enemy_Manager.aliens.Remove(this);
    }

    private void OnTriggerEnter2D(Collider2D wall)
    {
        WALL = wall.gameObject;

        Enemy_Manager.Move.x *= -1;
        Enemy_Manager.Move.y -= 1;


    }
    private void OnTriggerExit2D(Collider2D wañl)
    {
        Enemy_Manager.Move.y = 0;
        WALL = null;
    }




}
