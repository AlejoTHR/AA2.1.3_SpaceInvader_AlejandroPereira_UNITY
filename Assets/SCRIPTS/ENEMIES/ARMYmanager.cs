using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class ARMYmanager : MonoBehaviour
{

    [Header("UI MANAGER")]
    public UI_Manager UI_manager;
    public int ARMY_SCORE;

    [Header("SHOOT")]
    private int RandomOrigin;
    private Vector3 AlienBulletorigin;
    private int BulletOffsetSpanw;
    private float ShootCOUNT;
    public int ShootCOUNTmax;

    [Header("BULLET")]
    public GameObject AMMO;

    [Header("ROWS CONTROLLERS")]
    public float MINUScount = 0.005f;
    public float MINUScountmin = 0.1f;
    public float wait = 0.2f;

    [Header("ROW MANAGEMENT")]
    public bool _goingRight = true;
    public List<Rowmanager1> ROWS_manager;

    [Header("Aliens in ARMY")]
    public List<EnemyMovement> aliens_army;

    private void FixedUpdate()
    {
        AliensShoot();

        UI_manager.score = ARMY_SCORE;

    }
    
    public void AliensShoot()
    {
        ShootCOUNT += Time.deltaTime; // DELTA TIME TIMER

        if (ShootCOUNT >= ShootCOUNTmax && aliens_army.Count > 0)
        {
            RandomOrigin = Random.Range(0, aliens_army.Count); // CHOOSE RANDOM ALIEN THAT EXISTS

            AlienBulletorigin = new Vector3(aliens_army[RandomOrigin].transform.position.x, aliens_army[RandomOrigin].transform.position.y + BulletOffsetSpanw);
            GameObject newBullet = Instantiate(AMMO, AlienBulletorigin, aliens_army[RandomOrigin].transform.rotation);
            ShootCOUNT = 0;
            // 1- ORIGIN IS THE CHOSEN ALIEN
            // 2- CREATES THE BULLET FACING DOWN
            // 3- RESTARTS TIMER
        }
    }

    IEnumerator ChangeDirectionTIMER()
    {
        for (int i = ROWS_manager.Count - 1; i >= 0; i--)
        {
            ROWS_manager[i].Direction *= -1;
            ROWS_manager[i].transform.position -= new Vector3(0, 1, 0);
            yield return new WaitForSeconds(wait);
        }
    }
    public void ChangeDirection()
    {
        _goingRight = !_goingRight;
        StartCoroutine(ChangeDirectionTIMER());

    }
    public void Accelerate() // GETS CALLED IN ENEMY MOVEMENT
    {
        for (int i = ROWS_manager.Count - 1; i >= 0; i--)
        { // FOR EACH ROW, REDUCES MOVEMENT TIMER (Simulates Acceleration)
            ROWS_manager[i].COUNTmax -= MINUScount;
            
            if (aliens_army.Count == 1)
            { // LAST ALIEN STANDING GET A VELOCITY BOOST (LAST STAND)
                ROWS_manager[i].COUNTmax = MINUScountmin;
            }
            else if(aliens_army.Count == 0)
            {
                aliens_army.Clear();
            }
        }
    }



}


