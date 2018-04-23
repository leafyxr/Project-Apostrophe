using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
    public DialogueTrigger dialogue;
    public DialogueManager dialogueManager;
    public bool dialogueActive;
    public string nextScene;
    [SerializeField]
    GameObject eventBox;
    private bool paused;
  
    // Use this for initialization
    void Start () {
        paused = false;
        eventBox.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
    dialogueActive = dialogueManager.active;
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
            eventBox.SetActive(true);
            eventBox.GetComponent<EventBox>().pauseGame(paused);
            if (!paused)
            {
                eventBox.SetActive(false);
            }

        }
        else if (dialogueActive&&Input.anyKeyDown)
        {
            dialogueManager.displayNextLine();
        }
		else if (!dialogue.active&&Input.anyKeyDown)
        {
            endScene();
        }
        else if (Input.anyKeyDown)
        {
            dialogue.triggerDialogue();
        }
    }

    public void endScene()
    {
        eventBox.SetActive(true);
        eventBox.GetComponent<EventBox>().levelComplete();
    }

}
