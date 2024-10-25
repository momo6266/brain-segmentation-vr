using UnityEngine;

public class FeedbackButton : MonoBehaviour
{
    public string recipientEmail = "example@example.com";
    public string subject = "Feedback";
    public string body = "Please provide your feedback here.";

    // This method is triggered when the button is clicked
    public void OnFeedbackButtonClick()
    {
        string email = "mailto:" + recipientEmail + "?subject=" + EscapeURL(subject) + "&body=" + EscapeURL(body);
        Application.OpenURL(email);  // Open default email client with pre-filled content
    }

    // This method escapes special characters for URLs
    private string EscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }
}
