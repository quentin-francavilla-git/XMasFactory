using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] ITask[] tasks;

    [SerializeField] ElfController elf;

    public void TASK_DoTask(string taskName) {
        ITask task = GetTaskByName(taskName);

        if (!task) {
            Debug.LogError("Task:" + taskName + " Unknow");
            return;
        }

        task.GoToTask(elf);
    }

    ITask GetTaskByName(string taskName) {
        foreach (var task in tasks) {
            if (task.taskName.ToLower() == taskName.ToLower()) {
                return task;
            }
        }

        return null;
    }
}
