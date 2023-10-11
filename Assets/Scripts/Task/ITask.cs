using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITask : MonoBehaviour
{
    enum TaskStatus
    {
        inacitve
    }

    [HideInInspector] public string taskName;
    public Transform position;

    protected ElfController elf;

    public virtual void GoToTask(ElfController elf) {
        elf.GoTo(position.position);
        this.elf = elf;
    }
}
