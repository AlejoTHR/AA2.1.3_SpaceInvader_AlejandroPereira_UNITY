using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("SCORES RELATION")]
    public UIComponents UI_Components;
    public int SCORE;

    [Header("ARMY MANAGER")]
    public ARMYmanager ARMY_manager;

    [Header("PLAYER")]
    public PlayerController Player_Controller;
    public float BLINKwait = 0.25f;

    [Header("SHIELDS")]
    public List<SHIELD_MANAGER> SHIELDS;


    private void Awake()
    {

        // UI STARTS COMPONENTS HIDDEN
        Time.timeScale = 1f; // WHEN RESTART BUTTON SET TIME SCALE TO NORMAL
        UI_Components.WIN.gameObject.SetActive(false);
        UI_Components.GAMEOVER.gameObject.SetActive(false);
        UI_Components.Restart.gameObject.SetActive(false);
        UI_Components.Restart_text.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (SHIELDS.Count == 0) GAMEOVER_Defeat(); // IF SHIELDS LIST IS EMPTY
                                                   
        else if (ARMY_manager.aliens_army.Count == 0) GAMEOVER_Victory(); // IF ALIENS IN ARMY LIST IS EMPTY

        else if (UI_Components.lives == 0) GAMEOVER_Defeat(); // IF LIVES COUNT REACHES 0
    }


    public void GAMEOVER_Victory()
    {
        Time.timeScale = 0; // PAUSE THE SCENE
        // UI Victory COMPONENETS TURN ON
        UI_Components.WIN.gameObject.SetActive(true);
        UI_Components.Restart.gameObject.SetActive(true);
        UI_Components.Restart_text.gameObject.SetActive(true);
        Player_Controller.plyrInpyt.enabled = false; // DISABLES PLAYER SHOOTING


    }
    public void GAMEOVER_Defeat() // PAUSE THE SCENE
    {
        Time.timeScale = 0;
        // UI Defeat COMPONENETS TURN ON
        UI_Components.GAMEOVER.gameObject.SetActive(true);
        UI_Components.Restart.gameObject.SetActive(true);
        UI_Components.Restart_text.gameObject.SetActive(true);
        Player_Controller.gameObject.SetActive(false); // PLAYER IS DEACTIVATED

    }

    public IEnumerator PlayerhurtBlink()
    {
        // BUCLE SYS
        // 0- SET COLLIDER OFF
        // 1-PLAYER SPRITE RENDERER OFF
        // 2-WAIT 0.25f SECONDS
        // 3-PLAYER SPRITE RENDERER ON
        // REPEAT
        // 4- SETT COLLIDER ON ( COLLIDER HAS TO END IN TRUE!!!!!!!! )
        Player_Controller.cllder.enabled = false;

        Player_Controller.SprtRenderer.enabled = false;
        yield return new WaitForSeconds(BLINKwait); // WAITS
        Player_Controller.SprtRenderer.enabled = true;
        yield return new WaitForSeconds(BLINKwait); // WAITS
        Player_Controller.SprtRenderer.enabled = false;
        yield return new WaitForSeconds(BLINKwait);
        Player_Controller.SprtRenderer.enabled = true;
        yield return new WaitForSeconds(BLINKwait);
        Player_Controller.SprtRenderer.enabled = false;
        yield return new WaitForSeconds(BLINKwait);
        Player_Controller.SprtRenderer.enabled = true;

        Player_Controller.cllder.enabled = true;
    }

    public void PlayerHurt()
    {
        UI_Components.lives--; // UI MANAGER LIVES' COUNT -1 WHEN PLAYER GETS HURT
                            
        Destroy(UI_Components.LIVES[UI_Components.lives]); // DESTROY UI GAME OBJECT "LIVE"
    }
 
    public void RESTART()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // RESTART SCENE (RESTART GAME)
    }

}
