//using System;
using UnityEngine;

namespace SaladChef
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private ProgressBar m_WaitTimeMeter = default;
        [SerializeField] private Vegetables m_AvailableVegetables = default;
        [SerializeField] private int m_MinVegetablesSalad = 2;
        [SerializeField] private int m_MaxVegetablesInSalad = 3;
        [SerializeField] private float m_WaitTimePerVegetable = default;
        [SerializeField] private int m_ScoreForDelivery = 10;

        public Table pReservedTable { get; set; }
        public Chef pOrderedTakenByChef { get; set; }

        private float mWaitTime = 0;
        private float mTimeElapsed = 0;
        private bool mIsSaladOrdereSelected = false;
        private bool mIsAngry;
        private Salad mSalad = new Salad();

        private void Start()
        {
            RequestSalad();
        }

        private void RequestSalad()
        {
            mSalad.Clear();
            int noOfVegetablesInSalad = UnityEngine.Random.Range(m_MinVegetablesSalad, m_MaxVegetablesInSalad + 1);
            int[] randomNumberdArray = GetRandomNumberdArray(m_AvailableVegetables.pVegetables.Length);

            for (int i = 0; i < noOfVegetablesInSalad; ++i)
            {
                Vegetable vegetable = m_AvailableVegetables.pVegetables[randomNumberdArray[i]];
                mSalad.AddVegetable(vegetable);
                GameObject obj = m_AvailableVegetables.CreateVegetable(vegetable, pReservedTable.orderPlaceHolder);
                obj.GetComponent<Collider2D>().enabled = false;
            }

            pReservedTable.pCustomer = this;
            mWaitTime = m_WaitTimePerVegetable * noOfVegetablesInSalad;
            m_WaitTimeMeter.pProgress = (mWaitTime - mTimeElapsed) / mWaitTime;
            pReservedTable.orderPlaceHolder.GetComponent<TransformLayout>().ForcedUpdate();
            mIsSaladOrdereSelected = true;
        }

        public bool ReceiveSalad(Chef chef, Salad salad)
        {
            bool isCorrectSaladCombination = mSalad.Equals(salad);
            if (isCorrectSaladCombination)
            {
                if (mTimeElapsed / mWaitTime * 100 < 70)
                    SpawnPowerup();
                chef.pScore += m_ScoreForDelivery;
                LeaveTable();
            }
            else
            {
                if (mIsAngry)
                    chef.pScore -= m_ScoreForDelivery * 2;
                mIsAngry = true;
            }
            return isCorrectSaladCombination;
        }

        private void SpawnPowerup()
        {
            // Spawn powerups
        }

        public void Update()
        {
            if (mIsSaladOrdereSelected)
            {
                mTimeElapsed += mIsAngry ? Time.deltaTime * 2 : Time.deltaTime;
                m_WaitTimeMeter.pProgress = (mWaitTime - mTimeElapsed) / mWaitTime;

                if (mTimeElapsed >= mWaitTime)
                {
                    LeaveTable();
                }
            }
        }

        private void FeedBack()
        {

        }

        private void LeaveTable()
        {
            Reset();
            RequestSalad();
        }

        private void Reset()
        {
            pReservedTable.orderPlaceHolder.ClearChildren();
            pReservedTable.pCustomer = null;
            pOrderedTakenByChef = null;
            mTimeElapsed = 0;
            mWaitTime = 0;
            mIsSaladOrdereSelected = false;
            mSalad.Clear();
            mIsAngry = false;
        }

        private int[] GetRandomNumberdArray(int length)
        {
            int[] arr = new int[length]; 

            for (int i = 0; i < length; i++)
                arr[i] = i;
         
            for (int i = length - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            return arr;
        }
    }
}
