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
    public bool bInstantLevelEnd;
    public string nextScene;//Next Level Scene
    public string currentScene;//Current Level Scene
    private string loadScene;//Scene to be loaded when button clicked
    public AudioClip deathsound;
    public AudioClip winsound;
    private void Start()
    {
        
    }
    public void pauseGame(bool paused)
    {
        loadScene = currentScene;
        UI.SetActive(!paused);
        AudioSource[] allaudio = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        if (paused) 
        {
            foreach (AudioSource audio in allaudio)
            {
                audio.Pause();
            }
            Time.timeScale = 0;
            eventText.GetComponent<Text>().text = "Game Paused\nPress Esc to Continue";
            sceneButton.GetComponent<Text>().text = "Restart Level";
        }
        else
        {
            foreach (AudioSource audio in allaudio)
            {
                audio.UnPause();
            }
            Time.timeScale = 1;
        }
    }
    void gameOver()
    {
        AudioSource[] allaudio = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach(AudioSource audio in allaudio)
        {
            audio.Pause();
        }
        GetComponent<AudioSource>().PlayOneShot(deathsound);
        Time.timeScale = 0;
        UI.SetActive(false);
        eventText.GetComponent<Text>().text = "Game Over! \n Please try again";
        sceneButton.GetComponent<Text>().text = "Restart Level";
        loadScene = currentScene;
    }
    public void levelComplete()
    {
        if (bInstantLevelEnd)
        {
            loadScene = nextScene;
            ChangeScene();
        }
        AudioSource[] allaudio = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audio in allaudio)
        {
            audio.Pause();
        }
        GetComponent<AudioSource>().PlayOneShot(winsound);
        GetComponent<AudioSource>().loop = true;
        Time.timeScale = 0;
        UI.SetActive(false);
        eventText.GetComponent<Text>().text = "Level Complete!";
        sceneButton.GetComponent<Text>().text = "Next Level";
        loadScene = nextScene;
    }
    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(loadScene);
    }
    public void exitGame()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
