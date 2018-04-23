using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    public Text Name;
    public Text displayText;
    public bool active;
    private Queue<string> dialoguetext;
    public Animator animator;
    public AudioClip typesound;
    public AudioClip newline;
    // Use this for initialization
    void Start()
    {
        active = false;
        dialoguetext = new Queue<string>();
    }
    private void Update()
    {
        animator.SetBool("isOpen", active);
    }
    public void startDialogue(Dialogue dialogue)
    {
        active = true;
        Name.text = dialogue.Name;
        foreach(string sentence in dialogue.Text)
        {
            dialoguetext.Enqueue(sentence);
        }
        displayNextLine();
    }
    public void displayNextLine()
    {
        GetComponent<AudioSource>().PlayOneShot(newline);
        if (dialoguetext.Count == 0)
        {
            endDialogue();
            return;
        }
        string sentence = dialoguetext.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeText(sentence));
    }

    IEnumerator typeText(string text)
    {
        displayText.text = "";
        foreach(char letter in text.ToCharArray())
        {
            GetComponent<AudioSource>().PlayOneShot(typesound);
            displayText.text += letter;
            yield return new WaitForSeconds(0.08f);
        }
    }

    void endDialogue()
    {
        active = false;
        GetComponent<DialogueTrigger>().sendDialouge();
    }
}

