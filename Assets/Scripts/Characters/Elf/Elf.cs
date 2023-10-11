using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : MonoBehaviour
{
    public enum Status {Resting, Working}
    public Status workStatus;

    public float speed = 10;
    public float energy = 100;
    public float transitionTime = .25f;

    public Material defaultMaterial;
    public Material highlightedMaterial;

    public Task[] tasks;

    // Start is called before the first frame update
    void Start()
    {
        // INIT WORK STATUS
        workStatus = Status.Resting;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnergy();
    }

    private void UpdateEnergy()
    {
        if (workStatus == Status.Resting)
            energy += Time.deltaTime;
        else
            energy -= Time.deltaTime;

        // NORMALIZE
        if (energy > 100)
            energy = 100;
        else if (energy < 0)
            energy = 0;
    }
}
