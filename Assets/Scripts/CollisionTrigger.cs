using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] private string defaultMessage = "Default Message";

    private static bool messaging = false;
    public static bool Messaging { get { return messaging; } }

    [SerializeField] private Message[] message;
    private int messageIndex = 0;
    private bool messageComplete = true;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) //displayMessage(defaultMessage);
            handlePlayerTagCollisionEnter(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            handlePlayerTagCollisionExit(collision);
    }

    virtual protected void handlePlayerTagCollisionExit(Collision2D collision)
    {
        displayClose();
    }

    virtual protected void handlePlayerTagCollisionEnter (Collision2D collision)
    {
        if(message.Length > 0 && messageComplete)
        {
            messageIndex = 0;
            messaging = true;
            messageComplete = false;
            displayMessage(getNextMessage());
        } else
        {
            exitMessage();
        }
    }

    virtual protected void exitMessage()
    {
        messaging = false;
        displayClose();
        messageComplete = true;
        message[messageIndex].ExitMessage();
    }

    private void Update()
    {
        if (!messageComplete)
        {
            if (Input.anyKeyDown)
            {
                if(hasNextMessage())
                {
                    messageIndex += 1;
                    displayMessage(getNextMessage());
                } else
                {
                    exitMessage();  
                }
            }
        }
    }

    protected string getNextMessage()
    {
        while (!message[messageIndex].active)
        {
            messageIndex += 1;
        }
        return message[messageIndex].message;
    }

    protected bool hasNextMessage()
    {
        int nextIndex = messageIndex + 1;
        while(nextIndex < message.Length)
        {
            if (message[nextIndex].active) return true;
            else nextIndex += 1;
        }
        return false;
    }

    private void displayMessage(string message)
    {
        FindObjectOfType<DisplayHandler>().DisplayMessage(message);
    }

    private void displayClose()
    {
        FindObjectOfType<DisplayHandler>().CloseDisplay();
    }

}
