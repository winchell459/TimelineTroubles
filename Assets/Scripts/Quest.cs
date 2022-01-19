using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest")]
public class Quest : ScriptableObject
{
    public string Name;
    public string ID;
    [TextArea] public string Description;
    public QuestState State;

    public enum QuestState
    {
        inactive,
        trigger,
        start,
        in_progress,
        completed,
        done
    }
}
