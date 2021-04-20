using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    [SerializeField] private List<GameObject> test = new List<GameObject>();
    [SerializeField] private GameObject nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < test.Count; i++)
        {
            if(test[i] == null)
            {
                test.RemoveAt(i);
            }
        }

        if(test.Count == 0)
        {
            nextLevel.SetActive(true);
        }
    }
}
