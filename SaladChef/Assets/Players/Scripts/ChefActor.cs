using Framework.FSM;
using Framework.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "Player/FSM/Actor")]
    public class ChefActor : Actor
    {
        public Chef chef;
        public TransformProperty chefTransform;
    }
}
