using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items", order = 1)]
public class ItemCode : ScriptableObject
{
    public GameObject Model;
    public float FirstCost;
    public int TimesBought;
    public float CurrentCost;
    public float LastCost;
    public float CPS;


}
