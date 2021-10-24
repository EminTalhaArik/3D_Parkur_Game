using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    public LayerMask obstacle;
    private RaycastHit hit;
    public LayerMask playerLayer;

    public float laserMultipler = 1;

    private bool hitActive;
    public float range = 100f;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            hitActive = true;

            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.07f * laserMultipler + Mathf.Sin(Time.time) / 50;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            hitActive = false;
        }


        if (Physics.Raycast(transform.position, transform.forward, out hit, range, playerLayer))
        {
            if (hitActive)
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<PlayerManager>().Death();
                }
            }
        }
    }
}
