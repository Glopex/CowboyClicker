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
}
