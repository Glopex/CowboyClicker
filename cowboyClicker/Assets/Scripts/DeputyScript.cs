using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeputyScript : MonoBehaviour
{
    [SerializeField] public GameManager manager;
    public GameObject deputyPrefab;
    public TextMeshProUGUI costTxt;
    public TextMeshProUGUI quanityTxt;
    public int numDeputy = 0;
    public int costDeputy = 250;
    public int currentPoints;
    public Transform[] spawnPoint;

    private void Start()
    {
        costTxt.text = costDeputy.ToString();
        quanityTxt.text = numDeputy.ToString();
    }


    void Update()
    {
        currentPoints = manager.score;
        costTxt.GetComponentInChildren<Text>().text = costDeputy.ToString();
        quanityTxt.GetComponentInChildren<Text>().text = numDeputy.ToString();
    }

   public void SpawnDeputy(int num)
    {

        if (currentPoints >= costDeputy)
        {
            numDeputy++;
            SpawnDeputy(numDeputy);
            costDeputy *= 3;
        }
        Instantiate(deputyPrefab, spawnPoint[num].position, spawnPoint[num].rotation);
    }
}
