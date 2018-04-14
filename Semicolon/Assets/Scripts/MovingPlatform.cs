using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    Vector2 tempPos = new Vector2();
    public float Amplitude = 0.5f;
    public float Frequency = 1f;
    public bool Vertical;
    // Use this for initialization
    void Start () {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Vertical)
            {
                tempPos = transform.position;
                tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * Frequency) * Amplitude;
                transform.position = tempPos;
            }
            else
            {
                tempPos = transform.position;
                tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * Frequency) * Amplitude;
                transform.position = tempPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
