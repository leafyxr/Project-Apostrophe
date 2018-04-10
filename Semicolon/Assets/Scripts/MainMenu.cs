using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string StartScene;
    private int time;
    public Text title;
    private string titletext;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(true);
        time = 0;
        titletext = title.text;
	}
	
	// Update is called once per frame
	void Update () {
        time++;
        if (time == 15)
        {
            title.text += "_";
        }
        if(time == 30)
        {
            title.text = titletext;
            time = 0;
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(StartScene);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
