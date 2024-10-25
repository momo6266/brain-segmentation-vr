using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public GameObject panelToHide;

    // This method will be called when the button is clicked
    public void HideThePanel()
    {
        panelToHide.SetActive(false); // Hide the panel
    }
}
