using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    public class CustomerSpawner : MonoBehaviour
    {
        [SerializeField] Table[] m_Tables = default;
        [SerializeField] GameObject m_PfCustomerTemplate = default;

        private List<Customer> mCustomers = new List<Customer>();

        public void SpawnCustomers(Action<Customer> notRecievedOrderCallback)
        {
            for (int i = 0; i < m_Tables.Length; ++i)
            {
                GameObject customerObj = Instantiate(m_PfCustomerTemplate, m_Tables[i].customerPlaceHolder, true);
                customerObj.transform.localPosition = Vector3.zero;
                Customer customer = customerObj.GetComponent<Customer>();
                customer.pReservedTable = m_Tables[i];
                customer.RegisterEvent(notRecievedOrderCallback);
                mCustomers.Add(customer);
            }
        }

        public void Pause(bool pause)
        {
            foreach (Customer customer in mCustomers)
                customer.enabled = !pause;
        }

        public void Reset()
        {
            mCustomers.Clear();
            foreach (Table table in m_Tables)
            {
                table.orderPlaceHolder.ClearChildren();
                table.customerPlaceHolder.ClearChildren();
            }
        }
    }
}
