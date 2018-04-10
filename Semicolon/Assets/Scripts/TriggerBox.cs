using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour {

    [SerializeField]
    GameObject Trigger;
	// Use this for initialization
	void Start () {
        Trigger.SetActive(false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Trigger.SetActive(true);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
