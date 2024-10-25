using UnityEngine;
using UnityEngine.UI;

public class ButtonScroller : MonoBehaviour
{
    public RectTransform textAndButtons;  // The RectTransform of the "Text and buttons" object to scroll
    public float scrollAmount = 20f;      // The amount of pixels to scroll per button press
    public Button upButton;               // The up button
    public Button downButton;             // The down button
    private float maxHeight;              // Max scrollable height

    private void Start()
    {
        // Add listeners to the buttons to call the ScrollUp and ScrollDown methods
        upButton.onClick.AddListener(ScrollUp);
        downButton.onClick.AddListener(ScrollDown);

        // Set the scroll to start at the top
        SetToTop();

        // Calculate the max scrollable height dynamically
        CalculateMaxHeight();
    }

    // Method to scroll up
    public void ScrollUp()
    {
        // Get the current anchored position of the textAndButtons object
        Vector2 newPosition = textAndButtons.anchoredPosition;

        // Scroll up (decrease y-position) and allow scrolling to the very top (y = 0)
        newPosition.y = Mathf.Max(newPosition.y - scrollAmount, 0f);  // Move up, but do not go above y = 0

        // Apply the new position
        textAndButtons.anchoredPosition = newPosition;
    }

    // Method to scroll down
    public void ScrollDown()
    {
        // Get the current anchored position of the textAndButtons object
        Vector2 newPosition = textAndButtons.anchoredPosition;

        // Recalculate the maxHeight if the content size changes dynamically
        CalculateMaxHeight();

        // Increase the y-position by the scrollAmount, but don't allow scrolling beyond the maxHeight
        newPosition.y = Mathf.Min(newPosition.y + scrollAmount, maxHeight);

        // Apply the new position
        textAndButtons.anchoredPosition = newPosition;
    }

    // Method to calculate the maximum scrollable height dynamically based on the content size
    private void CalculateMaxHeight()
    {
        // Calculate the height of the viewport and content
        float viewportHeight = GetComponent<RectTransform>().rect.height;
        float contentHeight = textAndButtons.rect.height;

        // Set the maxHeight to ensure that the content doesn't scroll beyond its bounds
        maxHeight = Mathf.Max(0, contentHeight - viewportHeight);

        // Debugging: Print out maxHeight, contentHeight, and viewportHeight for checking
        Debug.Log("Content Height: " + contentHeight + ", Viewport Height: " + viewportHeight + ", Max Scrollable Height: " + maxHeight);
    }

    // Method to reset the scroll position to the top
    private void SetToTop()
    {
        // Set the content position to the top (y = 0)
        textAndButtons.anchoredPosition = new Vector2(textAndButtons.anchoredPosition.x, 0f);
    }
}
