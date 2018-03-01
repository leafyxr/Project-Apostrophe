using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSign : MonoBehaviour {

    [SerializeField]
    GameObject Door;
    [SerializeField]
    private Sprite Sprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Door.GetComponent<ExitDoor>().bProgress)
        {
            GetComponent<SpriteRenderer>().sprite = Sprite;
        }
	}
}
