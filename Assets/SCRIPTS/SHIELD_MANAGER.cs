using UnityEngine;

public class SHIELD_MANAGER : MonoBehaviour
{
    [Header("SHIELDS")]
    public GAME_MANAGER Game_Manager;

    private void Awake()
    { // ADDS SHIELD TO THE SHIELD LIST
        Game_Manager.SHIELDS.Add(this);
    }


    private void OnDestroy()
    {
        Game_Manager.SHIELDS.Remove(this);
    }




}
