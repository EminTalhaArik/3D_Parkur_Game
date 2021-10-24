using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Transform checker;
    public LayerMask playerLayer;

    public float radius;

    public Vector3 velocity;

    private bool broke = false;

    void Update()
    {

        if (Physics.CheckBox(checker.position, new Vector3(radius, 2, radius), Quaternion.identity, playerLayer))
        {
            broke = true;
        }

        if (broke)
        {
            velocity.z -= Time.deltaTime / 200;
            transform.Translate(velocity);
        }
    }
}
