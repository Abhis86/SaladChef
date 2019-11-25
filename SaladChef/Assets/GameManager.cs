using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaladChef
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Vegetables m_Vegetables = default;
        [SerializeField] private CustomerSpawner m_CustomerSpawner = default;
        [SerializeField] private ChefView[] m_Chefs = default;
        [SerializeField] private ChoppingBoard[] m_ChoppingBoard = default;
        [SerializeField] int m_ReduceScoreOnNotDeliveringTheSalad = 5;
        [SerializeField] UIGameOver m_UIGameOver = default;

        private bool mGameOver = false;

        void Start()
        {
            m_Vegetables.Create();
            Initialize();
        }

        private void Initialize()
        {
            m_Chefs[0].transform.position = Vector2.right * 2;
            m_Chefs[1].transform.position = Vector2.left * 2;
            m_CustomerSpawner.SpawnCustomers(OnCustomerDidNoRecievOrded);
            for (int i = 0; i < m_Chefs.Length; ++i)
                m_Chefs[i].Pause(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (!mGameOver)
            {
                mGameOver = true;
                for (int i = 0; i < m_Chefs.Length; ++i)
                {
                    if (m_Chefs[i].pChef.pTimeLeft > 0)
                    {
                        mGameOver = false;
                        break;
                    }
                }

                if (mGameOver)
                {
                    for (int i = 0; i < m_Chefs.Length; ++i)
                        m_Chefs[i].Pause(true);
                    m_CustomerSpawner.Pause(true);
                    m_UIGameOver.ShowResult(m_Chefs[0].pChef, m_Chefs[1].pChef);
                }
            }
        }

        private void OnCustomerDidNoRecievOrded(Customer customer)
        {
            for (int i = 0; i < m_Chefs.Length; ++i)
                m_Chefs[i].pChef.pScore -= m_ReduceScoreOnNotDeliveringTheSalad;
        }

        public void RestartGame()
        {
            for (int i = 0; i < m_Chefs.Length; ++i)
            {
                m_Chefs[i].Reset();
                m_Chefs[i].pChef.Reset();
            }
            for (int i = 0; i < m_ChoppingBoard.Length; ++i)
                m_ChoppingBoard[i].Reset();
            m_CustomerSpawner.Reset();
            m_UIGameOver.gameObject.SetActive(false);
            Initialize();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
