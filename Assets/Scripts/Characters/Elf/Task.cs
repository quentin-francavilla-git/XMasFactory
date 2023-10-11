using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public float taskCompletion = 0f; // 0->100%

    // SCHEDULE MANAGEMENT
    public float taskInitTime = 0f;
    public float taskDuration = 10; // Default task time set to 10s

    // FACTORY
    // public GameObject object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateTaskCompletion()
    {
        taskCompletion = (Time.deltaTime - taskInitTime) / taskDuration;
    }
}
