using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadTrigger : CollisionTrigger
{
    [SerializeField] private string sceneName;
    public bool Active;
    protected override void exitMessage()
    {
        base.exitMessage();
        loadScene();
    }

    private void loadScene()
    {
        if (Active) UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
