using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTriggerObject : MonoBehaviour
{
    //[SerializeField] protected Quest quest;
    //[SerializeField] protected Quest.QuestState[] activeOnStates;

    [SerializeField] private Quest triggerQuest;
    [SerializeField] private Quest.QuestState triggerState;
    [SerializeField] private Quest.QuestState[] triggerOnStates;

    [SerializeField] private bool destroyOnTriggered;
    [SerializeField] private InventoryObject objectNeeded;

    [SerializeField] private QuestTriggerObject[] NeededQuestTriggerObjects;
    public bool destroyed;

    // Start is called before the first frame update
    void Start()
    {
        destroyCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && FindObjectOfType<Inventory>().hasObject(objectNeeded))
        {
            if (checkOnStates(triggerOnStates))
            {
                destroyed = true;
                if(checkNeededQuestTriggerObjects()) triggerQuest.State = triggerState;
                Destroy(gameObject);
            }
        }
    }

    private bool checkNeededQuestTriggerObjects()
    {
        bool completed = true;
        foreach(QuestTriggerObject questTriggerObject in NeededQuestTriggerObjects)
        {
            Debug.Log(questTriggerObject);
            if (questTriggerObject != null && questTriggerObject.gameObject != gameObject && !questTriggerObject.destroyed) completed = false;
        }
        

        return completed;
    }

    private void destroyCheck()
    {
        if(triggerQuest.State >= triggerState)
        {
            Destroy(gameObject);
        }
    }

    protected bool checkOnStates(Quest.QuestState[] questStates)
    {
        foreach (Quest.QuestState questState in questStates)
        {
            if (destroyOnTriggered && triggerQuest.State == questState) return true;
        }
        return false;
    }
}
