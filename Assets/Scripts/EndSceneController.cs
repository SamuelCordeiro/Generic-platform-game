using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjectsGoals = new List<GameObject>();
    [SerializeField] private List<GameObject> nextLevel = new List<GameObject>();
    private bool inconpleteGoals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gameObjectsGoals.Count; i++)
        {
            if(gameObjectsGoals[i] == null)
            {
                gameObjectsGoals.RemoveAt(i);
            }
        }

        if(gameObjectsGoals.Count == 0 && !inconpleteGoals)
        {
            inconpleteGoals = true;
            for (int i = 0; i < nextLevel.Count; i++)
            {
                nextLevel[i].SetActive(true);
            }
            
        }
    }
}
