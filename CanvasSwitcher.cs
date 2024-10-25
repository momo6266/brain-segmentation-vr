using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject[] objectsToHide;  // Objects to hide (e.g., Quiz Intro Canvas)
    public GameObject objectToShow;     // Object to show (e.g., Quiz Canvas)
    public Text startButtonText;  // Reference to the Start/End Quiz button's text

    public void ShowQuizHideIntro()
    {
        // Hide all the objects in the objectsToHide array
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }

        // Show the quiz object (Quiz Canvas)
        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
        }
    }

    public void ShowIntroHideQuiz()
    {
        // Only trigger when startButtonText is "End Quiz"
        if (startButtonText != null && startButtonText.text == "End Quiz")
        {
            // Show all objects in the objectsToHide array
            foreach (GameObject obj in objectsToHide)
            {
                obj.SetActive(true);
            }

            // Hide the quiz object (Quiz Canvas)
            if (objectToShow != null)
            {
                objectToShow.SetActive(false);
            }
        }
    }
}
