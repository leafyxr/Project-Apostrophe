using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour {
    public DialogueTrigger dialogue;
    public DialogueManager dialogueManager;
    public bool dialogueActive;
    public string nextScene;
	// Use this for initialization
	void Start () {

	}
    // Update is called once per frame
    void Update () {
        dialogueActive = dialogueManager.active;
        if (dialogueActive&&Input.anyKeyDown)
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
        SceneManager.LoadScene(nextScene);
    }

}
