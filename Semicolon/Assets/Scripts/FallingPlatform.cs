using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
    private float fAlphaValue;
    public GameObject[] PlatformPieces;
    public float RateOfChange = 1;
    float fCurrentTime;
    bool bOnPlatform;
    private float TimeOnPlatform;
    float fTimeOfFade;
    public float fDelay = 2;
	// Use this for initialization
	void Start () {
        bOnPlatform = false;
        TimeOnPlatform = 0;
}
	
	// Update is called once per frame
	void Update () {
        if (bOnPlatform)
        {
            TimeOnPlatform += Time.deltaTime;
            if (TimeOnPlatform >= fDelay)
            {
                foreach(GameObject platform in PlatformPieces)
                {
                    platform.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bOnPlatform = true;
            TimeOnPlatform = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bOnPlatform = false;
            TimeOnPlatform = 0;
        }
    }
}
