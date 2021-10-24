using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public bool playerEnter, playerExit;
    private bool spawned;

    public Transform[] droneSpaner;
    public GameObject dronePrefabs;

    public GameObject level;  //Þuanlýk 1 level bulunuyor.

    public GameObject destroyLevel;

    private void Awake()
    {
        playerEnter = false;
        spawned = false;
    }

    private void Update()
    {
        //Drone Spawn 
        if (!spawned)
        {
            if (playerEnter)
            {
                //Drone Spawn
                for (int i = 0; i < droneSpaner.Length; i++)
                {
                    Instantiate(dronePrefabs, droneSpaner[i].position, Quaternion.identity);

                }

                //Level Spawn
                spawnLevel();

                //Set Boolean
                spawned = true;
            }


        }
        if (playerExit)
        {
            if (destroyLevel != null)
            {
                Destroy(destroyLevel.gameObject);
            }
        }
    }
    private void spawnLevel()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 150);
        GameObject levelObject = Instantiate(level, position, Quaternion.identity);
        levelObject.GetComponent<LevelManager>().destroyLevel = this.gameObject;
    }

}
