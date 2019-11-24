using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    public class Table : MonoBehaviour
    {
        public Transform customerPlaceHolder;
        public Transform orderPlaceHolder;
        public Customer pCustomer { get; set; }
    }
}
