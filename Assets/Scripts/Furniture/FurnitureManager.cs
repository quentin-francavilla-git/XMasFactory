using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    [Serializable]
    public struct Furnitures
    {
        public GameObject furniture;
    }

    [SerializeField]
    private Furnitures[] furnitures;
}
