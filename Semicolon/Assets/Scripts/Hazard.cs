using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    [SerializeField]
    GameObject Player;
    public int DamageTaken = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.SendMessage("takeDamage", DamageTaken);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.SendMessage("takeDamage", DamageTaken);
    }
}
