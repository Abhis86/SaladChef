using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Powerup : MonoBehaviour
    {
        [SerializeField] protected string m_Action;
        [SerializeField] protected int m_Val;
        public Chef pChef { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ChefView chefView = collision.GetComponent<ChefView>();
            if (chefView != null && chefView.pChef == pChef)
            {
                chefView.SendMessage(m_Action, m_Val, SendMessageOptions.DontRequireReceiver);
                Destroy(this.gameObject);
            }
        }
    }
}
