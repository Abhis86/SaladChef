using UnityEngine;

namespace SaladChef
{
    public class VegetableView : MonoBehaviour
    {
        public Vegetable vegetable;
        public Chef pInUseByPlayer { get; set; }
    }
}
