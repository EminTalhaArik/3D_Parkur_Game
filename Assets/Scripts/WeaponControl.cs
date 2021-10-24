using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    //
    public LayerMask obtacleLayer;
    public Vector3 offset;
    RaycastHit hit;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public float coolDown;

    public AudioClip gunShotSound;

    public GameObject handObject;
    private void Update()
    {
        //Look

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obtacleLayer))
        {
            handObject.transform.LookAt(hit.point);
            handObject.transform.rotation *= Quaternion.Euler(offset);
        }


        //CoolDown
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        //Shot
        if (Input.GetMouseButtonDown(0) && coolDown <= 0)
        {
            //Create Bullet
            Instantiate(bulletPrefab, handObject.transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0));

            //Sound
            coolDown = 0.25f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunShotSound,0.4f);

            //Animation
            GetComponent<Animator>().SetTrigger("shot");

        }

    }

}
