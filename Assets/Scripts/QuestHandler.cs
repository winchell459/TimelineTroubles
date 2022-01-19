using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestHandler", menuName = "ScriptableObjects/QuestHandler")]
public class QuestHandler : ScriptableObject
{
    public DebugQuest[] Quests;
    [System.Serializable]
    public struct DebugQuest
    {
        public Quest quest;
        public bool dontClearOnLoad;
    }
    public void ResetQuests()
    {
        foreach (DebugQuest debugQuest in Quests)
        {
            if (!debugQuest.dontClearOnLoad) debugQuest.quest.State = Quest.QuestState.inactive;
        }
    }
}
