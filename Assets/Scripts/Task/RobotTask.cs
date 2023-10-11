using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTask : ITask
{
    private void Awake() {
        taskName = "Robot";
    }

    protected void MakeTask()
    {
        elf.isInTaskZone = false;
        Debug.Log("Task " + taskName + " roro");

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
