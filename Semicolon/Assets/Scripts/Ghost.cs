using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    [SerializeField]
    GameObject ghost;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ghost.SetActive(false);
       }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ghost.SetActive(true);
    }



    // Update is called once per frame
    void Update () {
		
	}
}
