using UnityEngine;

public class SHIELD_MANAGER : MonoBehaviour
{
    [Header("SHIELDS")]
    public GameManager Game_Manager;

    private void Awake()
    { // ADDS SHIELD TO THE SHIELD LIST
        Game_Manager.SHIELDS.Add(this);
    }

    private void OnDestroy()
    { // REMOVES FROM SHIELD LIST WHEN DESTROYED
        Game_Manager.SHIELDS.Remove(this);
    }




}
