using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Message", menuName = "ScriptableObjects/Messages/Message")]
public class Message : ScriptableObject
{ 
    [SerializeField] protected bool _active;
    [SerializeField] [TextArea] protected string _message;

    public bool active { get { return getActive(); } }
    public string message { get { return getMessage(); } }

    virtual protected bool getActive()
    {
        return _active;
    }

    virtual protected string getMessage()
    {
        return _message;
    }

    virtual public void ExitMessage()
    {

    }
}
