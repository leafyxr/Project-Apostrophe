using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    private bool bIsCollected;
    Vector2 tempPos = new Vector2();
    public float hoverAmplitude = 0.5f;
    public float hoverFrequency = 1f;
    public bool healthup;
   
    // Use this for initialization
    void Start () {
        bIsCollected = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (bIsCollected)
        {
            Destroy(gameObject,.1f);
        }
        if (Time.timeScale != 0)
        {
tempPos = transform.position;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * hoverFrequency) * hoverAmplitude;
        transform.position = tempPos;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
if (!bIsCollected)
        {
           
            bIsCollected = true;
            if (healthup)
            {

                    collision.gameObject.GetComponent<PlayerPlatformerController>().SendMessage("healthPickup");
            }
            else
            {

                    collision.gameObject.GetComponent<PlayerPlatformerController>().SendMessage("getCollectable");
            }
        }
    }
        }
        
}
