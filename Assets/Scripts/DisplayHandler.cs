using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHandler : MonoBehaviour
{

    [SerializeField] private GameObject displayWindow;
    [SerializeField] private Text displayText;
    // Start is called before the first frame update
    void Start()
    {
        closeDisplayWindow();
    }

    public void CloseDisplay()
    {
        closeDisplayWindow();
    }

    public void DisplayMessage(string message)
    {
        openDisplayWindow();
        setDisplayText(message);
    }

    private void openDisplayWindow()
    {
        displayWindow.SetActive(true);
    }

    private void closeDisplayWindow()
    {
        displayWindow.SetActive(false);
    }

    private void setDisplayText(string message)
    {
        displayText.text = message;

    }
}
