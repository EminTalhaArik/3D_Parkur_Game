using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float lifeTime = 5f;

    public bool enemyBullet;
    public float bulletRadius = 0.5f;
    public LayerMask playerLayer;

    public GameObject hitEffect;

    public AudioClip hitSound;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            try
            {
                Destroy(this.gameObject);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //Enemy Bullet
        if (enemyBullet)
        {
            if (Physics.CheckSphere(transform.position,bulletRadius,playerLayer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Ýf Hit To Enemy
        if(other.CompareTag("Enemy"))
        {
            GameObject drone = other.gameObject.transform.parent.gameObject;

            drone.GetComponent<Drone>().health -= 25;
            drone.GetComponent<AudioSource>().PlayOneShot(hitSound,0.4f);

        }

        //Hit
        Instantiate(hitEffect,transform.position,transform.rotation);
        try
        {
            Destroy(this.gameObject);
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}
