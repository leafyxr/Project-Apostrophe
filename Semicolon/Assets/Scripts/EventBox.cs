using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventBox : MonoBehaviour {

    [SerializeField]
    GameObject sceneButton;//Restart/Next Scene button
    [SerializeField]
    GameObject quitButton;
    [SerializeField]
    GameObject eventText;
    [SerializeField]
    GameObject UI;
    public string nextScene;//Next Level Scene
    public string currentScene;//Current Level Scene
    private string loadScene;//Scene to be loaded when button clicked
    public void pauseGame(bool paused)
    {
        loadScene = currentScene;
        UI.SetActive(!paused);
        if (paused) 
        {
            Time.timeScale = 0;
            eventText.GetComponent<Text>().text = "Game Paused\nPress Esc to Continue";
            sceneButton.GetComponent<Text>().text = "Restart Level";
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    void gameOver()
    {
        Time.timeScale = 0;
        UI.SetActive(false);
        eventText.GetComponent<Text>().text = "Game Over! \n Please try again";
        sceneButton.GetComponent<Text>().text = "Restart Level";
        loadScene = currentScene;
    }
    public void levelComplete()
    {
        Time.timeScale = 0;
        UI.SetActive(false);
        eventText.GetComponent<Text>().text = "Level Complete!";
        sceneButton.GetComponent<Text>().text = "Next Level";
        loadScene = nextScene;
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(loadScene);
        Time.timeScale = 1;
    }
    public void exitGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
