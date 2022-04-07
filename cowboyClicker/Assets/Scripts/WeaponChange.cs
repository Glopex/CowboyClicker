using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
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
