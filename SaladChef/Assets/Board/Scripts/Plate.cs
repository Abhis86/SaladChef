using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    public class Plate : MonoBehaviour
    {
        public Transform itemHolder;
        public bool pIsInUse { get; set; }
        public Salad pSalad { get; set; } = new Salad();
    }
}
