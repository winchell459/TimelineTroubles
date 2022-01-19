using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MessageQuest", menuName = "ScriptableObjects/Messages/MessageQuest")]
public class MessageQuest : Message
{
    [SerializeField] protected Quest quest;
    [SerializeField] protected Quest.QuestState[] activeOnStates;

    override protected bool getActive()
    {
        if (_active) return _active;
        else return checkOnStates(activeOnStates);
    }

    protected bool checkOnStates(Quest.QuestState[] questStates)
    {
        foreach(Quest.QuestState questState in questStates)
        {
            if (quest.State == questState) return true;
        }
        return false;
    }

}
