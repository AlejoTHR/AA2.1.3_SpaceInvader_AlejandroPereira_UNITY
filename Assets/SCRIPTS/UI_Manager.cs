using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("ENEMY MANAGER")]
    public ARMYmanager ARMY_manager;


    [Header("SCORES")]
    public List<GameObject> LIVES;
    public int score;
    public TextMeshProUGUI SCORE;
    public TextMeshProUGUI GAMEOVER;
    public Button Restart;
    public TextMeshProUGUI Restart_text;

    private void Update()
    {
        SCORE.text = score.ToString(); // ADDS SCORE
    }






}
