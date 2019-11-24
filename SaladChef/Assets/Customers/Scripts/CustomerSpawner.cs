using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    public class CustomerSpawner : MonoBehaviour
    {
        [SerializeField] Table[] m_Tables = default;
        [SerializeField] GameObject m_PfCustomerTemplate = default;

        private void Start()
        {
            SpawnCustomers();
        }

        private void SpawnCustomers()
        {
            for (int i = 0; i < m_Tables.Length; ++i)
            {
                GameObject customerObj = Instantiate(m_PfCustomerTemplate, m_Tables[i].customerPlaceHolder, true);
                customerObj.transform.localPosition = Vector3.zero;
                customerObj.GetComponent<Customer>().pReservedTable = m_Tables[i];
            }
        }
    }
}
