using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    public Dialogue[] dialouge;
    public DialogueController controller;
    private int index;
    public bool active;

    private void Start()
    {
        active = true;
        index = 0;
    }
    public void triggerDialogue()
    {
        sendDialouge();
    }
    public void sendDialouge()
    {

        Debug.Log(index + " / " + dialouge.Length);
        if (index >= dialouge.Length)
        {
            if (index > dialouge.Length) {
                GetComponent<DialogueManager>().active = false;
                controller.endScene();
            }
        }
        else
        {
            Dialogue current = dialouge[index];
            GetComponent<DialogueManager>().startDialogue(current);
        }
        index++;
    }

}
