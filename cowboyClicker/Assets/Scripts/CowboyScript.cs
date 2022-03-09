using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyScript : MonoBehaviour
{
    public GameManager manager;
    public GameObject effect;
    public Transform scorePos;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public HealthBar healthBar;


    void OnEnable()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, 10f);
    }

    void OnTriggerStay(Collider other)
    {
        // Wooden Target 
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            
            Destroy(other.gameObject);
            manager.AddScore(10);
            healthBar.EditHealth(1);


            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            GameObject points = Instantiate(effect, scorePos.position = new Vector3(randomX,randomY,5), scorePos.transform.rotation);
            Destroy(points, 0.5f);
        }
    }
}
