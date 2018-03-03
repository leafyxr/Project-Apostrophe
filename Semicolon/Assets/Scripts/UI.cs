using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Door;
    [SerializeField]
    Image Health1;
    [SerializeField]
    Image Health2;
    [SerializeField]
    Image Health3;
    [SerializeField]
    Image Health4;
    [SerializeField]
    Image Health5;
    [SerializeField]
    Text ObjText;
    [SerializeField]
    Sprite heart;
    [SerializeField]
    Sprite damagedHeart;
    [SerializeField]
    GameObject eventBox;
    public string levelObjective;
    private int CurrentHeartsDisplayed;
    private int currentHealth;
    


    // Use this for initialization
    void Start () {
        ObjText.text = levelObjective;
        eventBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        currentHealth = Player.GetComponent<PlayerPlatformerController>().CurrentHealth;
      if (currentHealth != CurrentHeartsDisplayed)
        {
            if (currentHealth == 5)
            {
                setHeart(Health1, heart);
                setHeart(Health2, heart);
                setHeart(Health3, heart);
                setHeart(Health4, heart);
                setHeart(Health5, heart);
            }
            else if (currentHealth == 4)
            {
                setHeart(Health5, damagedHeart);
            }
            else if (currentHealth == 3)
            {
                setHeart(Health4, damagedHeart);
            }
            else if (currentHealth == 2)
            {
                setHeart(Health3, damagedHeart);
            }
            else if (currentHealth == 1)
            {
                setHeart(Health2, damagedHeart);
            }
            else if (currentHealth == 0)
            {
                setHeart(Health1, damagedHeart);
            }
            CurrentHeartsDisplayed = currentHealth;
        }
        if (Door.GetComponent<ExitDoor>().bProgress)
        {
            ObjText.text = "Get to the exit!";
        }
        else
        {
            ObjText.text = levelObjective + Player.GetComponent<PlayerPlatformerController>().iCollectables + " / " + Door.GetComponent<ExitDoor>().collectablesNeeded;
        }

	}

    void setHeart(Image Health, Sprite sHeart)
    {
        Health.sprite = sHeart;
    }
}
