using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firepoint;
    public Transform gun;
    public GameObject bullet;

    public float shootForce = 500.0f;
    Vector2 centerScreen;

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitPoint;

        if (Physics.Raycast(ray, out hitPoint, 100.0f))
        {
            gun.transform.LookAt(hitPoint.point);
        }
    }

    public void Fire(){

        bullet = Instantiate(bullet, firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * shootForce);
        Destroy(bullet.gameObject, 3f);

    }
}
