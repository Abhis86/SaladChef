using Framework.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    public class VegetableView : MonoBehaviour, IInteractable
    {
        public Vegetable vegetable;
        public Chef pInUseByPlayer { get; set; }
    }
}
