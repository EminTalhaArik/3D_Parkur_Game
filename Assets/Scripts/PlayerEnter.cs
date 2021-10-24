using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    public LevelManager levelManager;
    public bool enter;

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            levelManager.playerEnter = true;
        }
        else
        {
            levelManager.playerEnter = false;
        }
    }
}
