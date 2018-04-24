using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeStartTrigger : MonoBehaviour {
    public DialogueController controller;
	// Use this for initialization
	void Start () {
        controller.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            controller.enabled = true;
            Destroy(gameObject, 1f);
        }
    }
}
