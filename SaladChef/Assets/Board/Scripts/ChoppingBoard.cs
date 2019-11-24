using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    public class ChoppingBoard : MonoBehaviour
    {
        public Plate plate;
        public Transform itemHolder;
        public bool pIsInUse { get; set; }

        public void Reset()
        {
            plate.itemHolder.ClearChildren();
            plate.pIsInUse = false;
            itemHolder.ClearChildren();
            pIsInUse = false;
        }
    }
}
