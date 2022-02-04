using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Quest triggerQuest;
    [SerializeField] private Quest.QuestState triggerState;
    [SerializeField] private Quest.QuestState[] triggerOnStates;
    private bool questState { get { return checkQuestState(triggerQuest, triggerOnStates); } }

    [SerializeField] int enemyMaxCount = 5;
    [SerializeField] int enemyTotalCount = 10;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] Transform[] enemySpawnPoints;
    [SerializeField] Transform[] soldiers;

    [SerializeField] List< GameObject> enemies;
    int enemySpawned = 0;
    [SerializeField] float spawnRate = 3;
    float lastSpawned;
    // Update is called once per frame
    void Update()
    {
        int enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (questState && Time.time > lastSpawned + spawnRate &&  enemyCount < enemyMaxCount && enemySpawned < enemyTotalCount)
        {
            int rand = Random.Range(0, enemySpawnPoints.Length);
            Instantiate(enemyPrefab, enemySpawnPoints[rand].position, Quaternion.identity);
            enemySpawned += 1;
            lastSpawned = Time.time;
        }
        else if(questState && enemyCount == 0 && enemyTotalCount == enemySpawned)
        {
            triggerQuest.State = triggerState;
        }
        else if(!questState)
        {
            lastSpawned = Time.time;
        }
    }

    public void EnemyDead()
    {

    }

    bool checkQuestState(Quest quest, Quest.QuestState[] questTriggeredStates)
    {
        foreach(Quest.QuestState questState in questTriggeredStates)
        {
            if (quest.State == questState) return true;
        }
        return false;
    }

    public Transform[] GetSoldierTargets()
    {
        return soldiers;
    }
}
