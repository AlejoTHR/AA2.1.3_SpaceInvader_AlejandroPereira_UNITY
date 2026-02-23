using System.Collections.Generic;
using UnityEngine;

public class ARMYmanager : MonoBehaviour
{
    [Header("SHOOT")]
    public int RandomOrigin;
    public Vector3 AlienBulletorigin;
    public int BulletOffsetSpanw;

    public int COUNT;
    public int COUNTmax;

    [Header("BULLET")]
    public GameObject AMMO;

    [Header("ROW MANAGEMENT")]
    public EnemyMovement EnemyMovement;


    [Header("Aliens in ARMY")]
    public List<EnemyMovement> aliens_army;

    private void Start()
    {
        

    }

    private void FixedUpdate()
    {
        COUNT++;
        if(COUNT >= COUNTmax)
        {
            RandomOrigin = Random.Range(0, aliens_army.Count);


            AlienBulletorigin = new Vector3(aliens_army[RandomOrigin].transform.position.x, aliens_army[RandomOrigin].transform.position.y + BulletOffsetSpanw);
            GameObject newBullet = Instantiate(AMMO, AlienBulletorigin, aliens_army[RandomOrigin].transform.rotation);
            COUNT = 0;
        }



    }

    /*
     
         private void OnTriggerEnter2D(Collider2D wall)
    { // ENTERS THE LIMIT AND CHANGES DIRECTION
        if(wall.gameObject.CompareTag("Wall_Left") || wall.gameObject.CompareTag("Wall_Right"))
        {
            WALL = wall.gameObject;

            Enemy_Manager.Move.x *= -1;
            Enemy_Manager.Move.y -= 1;
        }
    }
    private void OnTriggerExit2D(Collider2D wall)
    { // EXITS THE LIMIT AND CHANGES DIRECTION
        if (wall.gameObject.CompareTag("Wall_Left") || wall.gameObject.CompareTag("Wall_Right"))
        {
            Enemy_Manager.Move.y = 0;
            WALL = null;
        }
    }
    private void OnTriggerStay2D(Collider2D collided)
    { // DESTROY SHIELD ON CONTACT
        if (collided.gameObject.CompareTag("Shield"))
        {
            Destroy(collided.gameObject);
        }
    }

     */











}
