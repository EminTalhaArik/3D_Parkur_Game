using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;

    public float speed = 1;
    public float fallowDistance;

    private float cooldown = 2f;

    public GameObject mesh;

    public GameObject bulletPrefab;
    public Vector3 bulletOffset;

    public float health = 100f;

    public GameObject deathEffect;
    public AudioClip deathSound;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FallowPlayer();
        Shot();
    }

    private void FixedUpdate()
    {
        Death();
    }

    private void Shot()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;
            //Shot
            mesh.GetComponent<Animator>().SetTrigger("shot");
            Instantiate(bulletPrefab,transform.position,transform.rotation * Quaternion.Euler(bulletOffset));
        }
    }

    private void FallowPlayer()
    {
        //Look To Player

        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(new Vector3(-116f, -85f, -96f));

        //Move To Player

        if (Vector3.Distance(transform.position, player.position) >= fallowDistance)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), Time.deltaTime * speed);
        }
    }

    private void Death()
    {
        if(health <= 0)
        {
            //Death Sound Effect
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(deathSound,0.4f);

            //Spawn Particle
            Instantiate(deathEffect, transform.position,Quaternion.identity);

            //Destroy GameObject
            Destroy(gameObject);
        }
    }

}
