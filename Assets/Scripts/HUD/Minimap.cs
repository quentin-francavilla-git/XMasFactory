using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject Elf_1;

    // Update is called once per frame
    void Update()
    {
        transform.position = Elf_1.transform.position;
    }
}
