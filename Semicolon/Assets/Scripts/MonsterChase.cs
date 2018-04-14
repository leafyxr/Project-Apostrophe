using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x - 0.5f, Player.transform.position.y), speed * Time.deltaTime);
    }
}

