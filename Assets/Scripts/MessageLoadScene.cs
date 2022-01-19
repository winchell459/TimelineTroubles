using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MessageLoadScene", menuName = "ScriptableObjects/Messages/MessageLoadScene")]
public class MessageLoadScene : MessageQuest
{
    [SerializeField] private string sceneName;
    //protected override string getMessage()
    //{
    //    return _message;
    //}

    override public void ExitMessage()
    {
        if (_active || checkOnStates(activeOnStates))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}