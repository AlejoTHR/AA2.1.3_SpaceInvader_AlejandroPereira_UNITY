using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class ARMYmanager : MonoBehaviour
{

    [Header("SHOOT")]
    private int RandomOrigin;
    private Vector3 AlienBulletorigin;
    private int BulletOffsetSpanw;
    [SerializeField] float ShootCOUNT;
    public int ShootCOUNTmax;

    [Header("UI MANAGER")]
    public UIComponents UI_Components;
    public int ARMY_SCORE;

    [Header("BULLET")]
    public GameObject AMMO;

    [Header("ROWS CONTROLLERS")]
    [SerializeField] float MINUScount;
    [SerializeField] float MINUScountmin;
    [SerializeField] float wait;
    
    [Header("ROW MANAGEMENT")]
    public bool _goingRight = true;
    public List<Rowmanager1> ROWS_manager;

    [Header("Aliens in ARMY")]
    public List<EnemyMovement> aliens_army;

    private void Start()
    {
        // START COMPONENTS VALUES (I PUTTED THEM ALL IN PRIVATE OR SERIALIZED)
        BulletOffsetSpanw = 1;
        MINUScount = 0.005f;
        MINUScountmin = 0.01f;
        wait = 0.2f;
    }

    private void FixedUpdate()
    {
        UI_Components.score = ARMY_SCORE; // VARIBALE ACCESIBLE FOR GAME_MANAGER
        AliensShoot(); // SEE FUNCTION
    }
    
    public void AliensShoot()
    {
        ShootCOUNT += Time.deltaTime; // DELTA TIME TIMER FOR SHOOTING

        if (ShootCOUNT >= ShootCOUNTmax && aliens_army.Count > 0)
        {
            RandomOrigin = Random.Range(0, aliens_army.Count); // CHOOSE RANDOM ALIEN THAT EXISTS

            // ORIGIN VECTOR TO CREATE THE BULLET       // RANDOM ALIEN IN ARMY     // OFFSET BECAUSE IT PUSHES THE ALIEN
            AlienBulletorigin = new Vector3(aliens_army[RandomOrigin].transform.position.x, aliens_army[RandomOrigin].transform.position.y + BulletOffsetSpanw);

            // CREATE SAID BULLET IN ALIEN ORIGIN
            GameObject newBullet = Instantiate(AMMO, AlienBulletorigin, aliens_army[RandomOrigin].transform.rotation); 

            ShootCOUNT = 0; // RESET SHOOT COUNT
        }
    }

    IEnumerator ChangeDirectionTIMER()
    {
        for (int i = ROWS_manager.Count - 1; i >= 0; i--)
        {// FOR EVERY ALIEN ROW THAT EXISTS
            ROWS_manager[i].Direction *= -1; // CHANGES DIRECTION VARIABLE FROM ROW MANAGER

            ROWS_manager[i].transform.position -= new Vector3(0, 1, 0); // GOES -Y BY 1 UNIT

            yield return new WaitForSeconds(wait); // WAITS TO MAKE THE ILUSIONS OF ASYNCRONY

        }
    }
    public void ChangeDirection()
    {
        _goingRight = !_goingRight; // CHANGES STATE OF GOING RIGHT
        StartCoroutine(ChangeDirectionTIMER()); // SEE COROUTINE

    }
    public void Accelerate() // GETS CALLED IN ENEMY MOVEMENT
    {

        for (int i = ROWS_manager.Count - 1; i >= 0; i--)
        {// FOR EACH ROW, REDUCES MOVEMENT TIMER (Simulates Acceleration)
            ROWS_manager[i].COUNTmax -= MINUScount;

            if (aliens_army.Count == 1)
            { // LAST ALIEN STANDING GETS A VELOCITY BOOST (LAST STAND)
                ROWS_manager[i].COUNTmax = MINUScountmin;
            }
            else if (aliens_army.Count == 0)
            {
                aliens_army.Clear(); // LIST GETS CLEANED
            }

        }

    }



}


