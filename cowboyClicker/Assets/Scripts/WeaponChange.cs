using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    public GameObject PistolWeapon;
    public GameObject ShotgunWeapon;
    public GameObject GatlingWeapon;
    public bool Pistol;
    public bool Shotgun;
    public bool gatling;
    // Start is called before the first frame update
    void Start()
    {
        Pistol = true;
        Shotgun = false;
        gatling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pistol == true)
        {
            PistolWeapon.SetActive(true);
        }
        else
        {
            PistolWeapon.SetActive(false);
        }
        
        if (Shotgun == true)
        {
            ShotgunWeapon.SetActive(true);
        }
        else
        {
            ShotgunWeapon.SetActive(false);
        }
        
        if (gatling == true)
        {
            GatlingWeapon.SetActive(true);
        }
        else
        {
            GatlingWeapon.SetActive(false);
        }
    }


    void BuyShotgun()
    {
        print("boughtShotgun");
        Pistol = false;
        Shotgun = true;
    }


    void BuyGatling()
    {
        print("boughtGatling");
        Pistol = false;
        Shotgun = false;
        gatling = true;
    }
}
