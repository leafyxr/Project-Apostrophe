using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour {
    [SerializeField]
    GameObject Player;
    [SerializeField]
    public int collectablesNeeded = 3;
    [SerializeField]
    GameObject eventBox;
    public bool bProgress;
	// Use this for initialization
	void Start () {
        bProgress = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Player.GetComponent<PlayerPlatformerController>().iCollectables == collectablesNeeded)
        {
            bProgress = true;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bProgress)
        {
            eventBox.SetActive(true);
            eventBox.GetComponent<EventBox>().SendMessage("levelComplete");
        }
    }
}
