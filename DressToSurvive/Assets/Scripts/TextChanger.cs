using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    public TMP_Text textToChange;
    public string[] messages;

    private int currentIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Update text
            textToChange.text = messages[currentIndex];

            // Move to the next message (wrap around)
            currentIndex = (currentIndex + 1) % messages.Length;
        }
    }
}