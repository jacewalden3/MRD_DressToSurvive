/*
 * Description: Creates a dialogue popup when the player interacts with the NPC.
 * The dialogue has a dynamic typing effect :) Dialogues have multiple lines and can
 * be tabbed through.
 * Author: Jocelyn Le
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour {

    public GameObject dialogueBox;
    public TextMeshProUGUI displayedText;
    public string[] dialogueLines;
    public float textSpeed = 0.05f; // wait a fraction of a second before writing the next character to the screen 
    int idx;
    bool printedOnce;

    // Start is called before the first frame update
    void Start()
    {
        printedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"interaction enabled is currently {interactionEnabled}");

        if (displayedText != null)
        {
            if (!printedOnce)
            {
                displayedText.text = string.Empty;
                PrintToScreen();
                printedOnce = true;
            }
            
        }
        else
        {
            Debug.LogError("No dialogue or text object found");
        }


        // handle printing the next line of the dialogue
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (displayedText.text == dialogueLines[idx]) // finished writing the current dialogue line
            {
                NextLine();
            } 
            else
            {
                StopAllCoroutines();
                displayedText.text = dialogueLines[idx];
            }
        }
    }

    void PrintToScreen()
    {
        idx = 0;
        StartCoroutine(ParseText());
    }

    // use coroutine when "speaking" state enabled
    IEnumerator ParseText()
    {
        foreach(char character in dialogueLines[idx].ToCharArray())
        {
            displayedText.text += character; // add each character individually to create a dynamic typing effect
            yield return new WaitForSeconds(textSpeed); // yield remembers the previous state, allowing it to resume from the right character with the right timing
        }
    }

    void NextLine()
    {
        if (idx < dialogueLines.Length - 1) // advance to the next line of dialogue
        {
            ++idx;
            displayedText.text = string.Empty;
            StartCoroutine(ParseText());
        } 
        else
        {
            printedOnce = false;
        }
    }
}
