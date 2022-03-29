using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public GameObject muzzlePrefab;
    private Transform target;
    int mode;

    public float speed = 1.0f;

    private void Start()
    {
        mode = 1;
    }
    void Update()
    {

        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                var ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    transform.LookAt(hit.point);

                    switch (mode)
                    {
                        case 1:  //Revolver Shooting
                            
                            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                            Instantiate(muzzlePrefab, firepoint.position, firepoint.rotation);
                            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed);

                            Destroy(bullet.gameObject, 10f);
                            break;
                        case 2: // Shotgun Shooting
                            break;
                        case 3: // Gatling Gun Shooting

                            break;
                    }
                }

            }
        }
        
    }
}
