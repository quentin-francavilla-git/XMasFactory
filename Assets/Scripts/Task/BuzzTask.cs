using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzTask : ITask
{
    private void Awake() {
        taskName = "Buzz";
    }

    protected void MakeTask()
    {
        elf.isInTaskZone = false;
        Debug.Log("Task " + taskName + " buzbuz");

        StartCoroutine(WaitAndCreate(8));
    }

    IEnumerator WaitAndCreate(float second)
    {
        yield return new WaitForSeconds(second);

        Debug.Log(taskName + " Created");

        elf.gift = taskName;
        elf = null;
    }

    private void Update() {
        if (!elf) {
            return;
        }

        if (elf.isInTaskZone) {
            MakeTask();
        }
    }
}
