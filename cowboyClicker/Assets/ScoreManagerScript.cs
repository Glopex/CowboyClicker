using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManagerScript : MonoBehaviour
{

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ScorePerSecond = (DeputyScore + HorseScore)/100;
        TotalScore = TotalScore + ScorePerSecond;

        DeputyScore = LevelDeputy ;
        HorseScore = LevelHorse * 5;


        //addScore.Invoke(TotalScore.ToString());
        TrueScorePerSecond = ScorePerSecond * 100; //this is mostly visual
    }
    void ClickScore(float CPC)
    {
        
        TotalScore = TotalScore + CPC;
    }

    public void increaseDeputy(float price)
    {

        if (TotalScore > price)
        {
            TotalScore = TotalScore - price;
            LevelDeputy++;
        }

        if(LevelDeputy>0 && Deputy == false)
        {
            Instantiate(deputy, new Vector3(gameObject.transform.position.x+1 , gameObject.transform.position.y , gameObject.transform.position.z - 0.5f), gameObject.transform.rotation);
            Deputy = true;
        }

    }

    public void increaseHorse(float price)
    {

        if (TotalScore > price)
        {
            TotalScore = TotalScore - price;
            LevelHorse++;
        }

        if (LevelHorse > 0 && Horse == false)
        {
            Instantiate(horse, new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
            Horse = true;
        }

    }

    public void GetShotgun(float price)
    {
        if (TotalScore > price && Shotgun == false)
        {
            TotalScore = TotalScore - price;
            GameObject.FindGameObjectWithTag("theboi").SendMessage("increaseBullet1");
            Shotgun = true;
        }
    }

    public void GetGatling(float price)
    {
        if (TotalScore > price && gat == false)
        {
            TotalScore = TotalScore - price;
            GameObject.FindGameObjectWithTag("theboi").SendMessage("increaseBullet2");
            gat = true;
        }
    }
}
