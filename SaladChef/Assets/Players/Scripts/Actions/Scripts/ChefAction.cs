using Framework.FSM;
using Framework.Scriptables;
using UnityEngine;

namespace SaladChef
{
    public abstract class ChefAction : GameAction
    {
        [SerializeField] protected Chef m_Chef = default;
        [SerializeField] protected TransformProperty m_ChefTransform = default;
    }
}