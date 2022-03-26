using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float ScorePerSecond;
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


        addScore.Invoke(TotalScore.ToString());
    }
    void ClickScore(float CPC)
    {
        
        TotalScore = TotalScore + CPC;
    }
}
