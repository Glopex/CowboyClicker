using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public ItemCode newobject;
    [Header("Deputy")]
    public ItemCode DEPUTY;
    public TextMeshProUGUI costDeputyTxt;
    public TextMeshProUGUI quanityDeputyTxt;
    [Header("Horse")]
    public ItemCode HORSE;
    public TextMeshProUGUI costHorseTxt;
    public TextMeshProUGUI quanityHorseTxt;


    // Start is called before the first frame update
    void Start()
    {
        DEPUTY.FirstCost = 250f;
        DEPUTY.CurrentCost = DEPUTY.FirstCost;

        HORSE.FirstCost = 500f;
        HORSE.CurrentCost = HORSE.FirstCost;
    }

    // Update is called once per frame
    void Update()
    {

        costDeputyTxt.text = "$ " + DEPUTY.CurrentCost.ToString("F1");
        quanityDeputyTxt.text = DEPUTY.TimesBought.ToString("F1");

        costHorseTxt.text = "$ " + HORSE.CurrentCost.ToString("F1");
        quanityHorseTxt.text = HORSE.TimesBought.ToString("F1");
    }
}
