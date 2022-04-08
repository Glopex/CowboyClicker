using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public ItemCode DEPUTY;
    public ItemCode HORSE;
    public ItemCode DREAMCATCHER;
    public ItemCode CAMPFIRE;
    private float ScorePerSecond;
    public float TrueScorePerSecond;
    public float TotalScore;
    public float LevelDeputy;
    public float LevelHorse;
    private float DeputyScore;
    private float HorseScore;
    [SerializeField] public UnityEvent<string> addScore;
    [SerializeField] public int LevelGun = 1;
    [SerializeField] public GameObject deputy;
    [SerializeField] public GameObject horse;
    private bool Shotgun;
    private bool gat;
    private bool Deputy;
    private bool Horse;

    
    [SerializeField] public GameObject priceDeputy;
    [SerializeField] public GameObject priceHorse;
    [SerializeField] public GameObject priceDreamcatcher;
    [SerializeField] public GameObject priceCampfire;

    void Start()
    {
        ScorePerSecond = 0;
        TrueScorePerSecond = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        ScorePerSecond = ((DEPUTY.CPS * DEPUTY.TimesBought) + (HORSE.CPS * HORSE.TimesBought) + (DREAMCATCHER.CPS * DREAMCATCHER.TimesBought) + (CAMPFIRE.CPS * CAMPFIRE.TimesBought)) / 100;
        TotalScore = TotalScore + ScorePerSecond;
        FormatScore(TotalScore); // format score and then display it
        TrueScorePerSecond = ScorePerSecond * 100; //this is mostly visual
        CheckPrices();
    }
    void ClickScore(float CPC)
    {
        TotalScore = TotalScore + CPC;
    }

    void FormatScore(float TotalScore)
    {
        string scoreDisplay = TotalScore.ToString();

        if (TotalScore >= 1000000000) // 1 Billion
        {
            scoreDisplay = (TotalScore / 1000000000).ToString("F1") + "Bil";
        }
        else if (TotalScore >= 1000000) // 1 Million
        {
            scoreDisplay = (TotalScore / 1000000).ToString("F1") + "Mil";
        }
        else if (TotalScore >= 1000f) // 1 hundred thousands
        {
            scoreDisplay = (TotalScore / 1000).ToString("F1") + "K";
        }
        else scoreDisplay= TotalScore.ToString("F1");

        addScore.Invoke(scoreDisplay);
    }

    public void increaseItem(string NameObject)
    {

        print(NameObject);
        switch(NameObject)
        {
            case "Deputy":
               
                if(DEPUTY.TimesBought == 0 && TotalScore > DEPUTY.FirstCost)
                {
                    DEPUTY.CPS = 0.1f;
                    print("cringe");
                    TotalScore -= DEPUTY.CurrentCost;
                    Instantiate(DEPUTY.Model, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z - 0.5f), gameObject.transform.rotation);
                    DEPUTY.TimesBought++;
                    DEPUTY.LastCost = DEPUTY.FirstCost;
                    DEPUTY.CurrentCost = ((DEPUTY.LastCost * 15) / 100) + DEPUTY.LastCost;
                }
                else if(TotalScore > DEPUTY.LastCost)
                {
                    TotalScore -= DEPUTY.CurrentCost;
                    DEPUTY.TimesBought++;
                    DEPUTY.CurrentCost = ((DEPUTY.LastCost * 15) / 100) + DEPUTY.LastCost;
                    DEPUTY.LastCost = DEPUTY.CurrentCost;
                }
                break;
            case "Horse":
                if (HORSE.TimesBought == 0 && TotalScore > HORSE.FirstCost)
                {
                    
                    TotalScore -= HORSE.CurrentCost;
                    Instantiate(HORSE.Model, new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
                    HORSE.TimesBought++;
                    HORSE.LastCost = HORSE.FirstCost;
                    HORSE.CurrentCost = ((HORSE.LastCost * 15) / 100) + HORSE.LastCost;
                }
                else if (TotalScore > HORSE.LastCost)
                {
                    TotalScore -= HORSE.CurrentCost;
                    HORSE.TimesBought++;
                    HORSE.CurrentCost = ((HORSE.LastCost * 15) / 100) + HORSE.LastCost;
                    HORSE.LastCost = HORSE.CurrentCost;
                }
                break;
            case "Dreamcatcher":
                if (DREAMCATCHER.TimesBought == 0 && TotalScore > DREAMCATCHER.FirstCost)
                {
                    
                    TotalScore -= DREAMCATCHER.CurrentCost;
                    //Instantiate(HORSE.Model, new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
                    DREAMCATCHER.TimesBought++;
                    DREAMCATCHER.LastCost = DREAMCATCHER.FirstCost;
                    DREAMCATCHER.CurrentCost = ((DREAMCATCHER.LastCost * 15) / 100) + DREAMCATCHER.LastCost;
                }
                else if (TotalScore > DREAMCATCHER.LastCost)
                {
                    TotalScore -= DREAMCATCHER.CurrentCost;
                    DREAMCATCHER.TimesBought++;
                    DREAMCATCHER.CurrentCost = ((DREAMCATCHER.LastCost * 15) / 100) + DREAMCATCHER.LastCost;
                    DREAMCATCHER.LastCost = DREAMCATCHER.CurrentCost;
                }
                break;
            case "Campfire":
                if (CAMPFIRE.TimesBought == 0 && TotalScore > CAMPFIRE.FirstCost)
                {
                    
                    TotalScore -= CAMPFIRE.CurrentCost;
                    //Instantiate(HORSE.Model, new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
                    CAMPFIRE.TimesBought++;
                    CAMPFIRE.LastCost = CAMPFIRE.FirstCost;
                    CAMPFIRE.CurrentCost = ((CAMPFIRE.LastCost * 15) / 100) + CAMPFIRE.LastCost;
                }
                else if (TotalScore > CAMPFIRE.LastCost)
                {
                    TotalScore -= CAMPFIRE.CurrentCost;
                    CAMPFIRE.TimesBought++;
                    CAMPFIRE.CurrentCost = ((CAMPFIRE.LastCost * 15) / 100) + CAMPFIRE.LastCost;
                    CAMPFIRE.LastCost = CAMPFIRE.CurrentCost;
                }
                break;
        }
    }

    public void CheckPrices()
    {
        priceDeputy.GetComponent<TextMeshProUGUI>().text = DEPUTY.CurrentCost.ToString();
        priceHorse.GetComponent<TextMeshProUGUI>().text = HORSE.CurrentCost.ToString();
        priceDreamcatcher.GetComponent<TextMeshProUGUI>().text = DREAMCATCHER.CurrentCost.ToString();
        priceCampfire.GetComponent<TextMeshProUGUI>().text = CAMPFIRE.CurrentCost.ToString();
        //priceItem3.GetComponent<Text>().text = ITEM3.CurrentCost.ToString();
    }

    public void GetShotgun(float price)
    {
        if (TotalScore > price && Shotgun == false)
        {
            TotalScore = TotalScore - price;
            GameObject.FindGameObjectWithTag("theboi").SendMessage("increaseBullet1");
            GameObject.FindGameObjectWithTag("Weapon").SendMessage("BuyShotgun");
            Shotgun = true;
        }
    }

    public void GetGatling(float price)
    {
        if (TotalScore > price && gat == false)
        {
            TotalScore = TotalScore - price;
            GameObject.FindGameObjectWithTag("theboi").SendMessage("increaseBullet2");
            GameObject.FindGameObjectWithTag("Weapon").SendMessage("BuyGatling");
            gat = true;
        }
    }
}
