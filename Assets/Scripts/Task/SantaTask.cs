using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaTask : ITask
{

    private void Awake() {
        taskName = "Santa";
    }

    protected void MakeTask()
    {
        Debug.Log("Task Santa" + " santaaaaa");

        // la tu fais les bails quand tu donnes le cadeau
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
