using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIComponents : MonoBehaviour
{
    // EVERYTHING IS MANAGED IN GAME MANAGER, THIS SCRIPT IS FOR MORE THAN 1 LINK REFERENCES
    [Header("ENEMY MANAGER")]
    public ARMYmanager ARMY_manager;

    [Header("SCORES")]
    public List<GameObject> LIVES;
    public int lives = 2;
    public int score;
    public TextMeshProUGUI SCORE;

    [Header("DEFEAT")]
    public TextMeshProUGUI GAMEOVER;
    public Button Restart;
    public TextMeshProUGUI Restart_text;
    [Header("Victory")]
    public TextMeshProUGUI WIN;
    private void Update()
    {
        SCORE.text = score.ToString(); // ADDS SCORE TO UI
    }






}
