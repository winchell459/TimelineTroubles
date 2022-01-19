using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MessageTrigger", menuName = "ScriptableObjects/Messages/MessageTrigger")]
public class MessageTrigger : MessageQuest
{
    [SerializeField] private Quest triggerQuest;
    [SerializeField] private Quest.QuestState triggerState;
    [SerializeField] private Quest.QuestState[] triggerOnStates;

    override protected string getMessage()
    {
        if (_active || checkOnStates(triggerOnStates))
        {
            triggerQuest.State = triggerState;
        }
        return _message;
    }

}