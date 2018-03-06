using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamWorld : MonoBehaviour {
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject StartGrid;
    [SerializeField]
    GameObject MainGrid;

    // Use this for initialization
    void Start () {
        MainGrid.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.GetComponent<PlayerPlatformerController>().iCollectables != 0)
        {
            MainGrid.SetActive(true);
            StartGrid.SetActive(false);
        }
	}
}
