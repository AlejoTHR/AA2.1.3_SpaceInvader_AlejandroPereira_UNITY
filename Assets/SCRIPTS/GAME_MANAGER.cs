using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAME_MANAGER : MonoBehaviour
{
    [Header("SCORES RELATION")]
    public UI_Manager UImanager;

    public int LIVES = 3;
    public int SCORE;

    [Header("PLAYER")]
    public PlayerController Player_Controller;


    [Header("SHIELDS")]
    public List<SHIELD_MANAGER> SHIELDS;


    private void Awake()
    {
        Time.timeScale = 1f;


        UImanager.GAMEOVER.gameObject.SetActive(false);
        UImanager.Restart.gameObject.SetActive(false);
        UImanager.Restart_text.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        GAMEOVER();
    }

    public void PlayerHurt()
    {
        UImanager.LIVES[LIVES - 1].gameObject.SetActive(true);
        LIVES--;
    }

    public void GAMEOVER()
    {
        if (SHIELDS.Count == 0)
        {
            Time.timeScale = 0;

            UImanager.GAMEOVER.gameObject.SetActive(true);
            UImanager.Restart.gameObject.SetActive(true);
            UImanager.Restart_text.gameObject.SetActive(true);
        }  
    }

    public void RESTART()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
