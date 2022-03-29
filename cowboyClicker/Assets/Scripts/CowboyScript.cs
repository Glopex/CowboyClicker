using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowboyScript : MonoBehaviour
{
   [SerializeField] public GameManager manager;
    public GameObject effect;
    public Transform scorePos;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public HealthBar healthBar;
    public float CPC;
    public GameObject lvlTxt;
    public int lvlNum;


    private void Start()
    {
        lvlNum = 1;
        lvlTxt.GetComponentInChildren<Text>().text = "LVL :" + lvlNum;
    }

    // Update is called once per frame
    void Update()
    {
        CPC = manager.damage;

        if(healthBar.health<= 0)
        {
            healthBar.maxHealth *= 1.15f;
            healthBar.health = healthBar.maxHealth;
            lvlNum++;
        }

        lvlTxt.GetComponentInChildren<Text>().text = "Lvl :" + lvlNum;
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            
            Destroy(other.gameObject);
            manager.AddScore((int)CPC);
            healthBar.EditHealth(CPC);


            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            GameObject points = Instantiate(effect, scorePos.position = new Vector3(randomX,randomY,5), scorePos.transform.rotation);
            Destroy(points, 0.5f);
        }
    }
}
