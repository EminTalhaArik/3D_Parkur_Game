using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Ýf Player Fall To Lava
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().Death();
        }
    }
}
