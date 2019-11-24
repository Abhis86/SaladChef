using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SaladChef
{
    public class UIGameOver : UIBehaviour
    {
        [SerializeField] private Text m_GameResult = default;

        public void ShowResult(Chef chef1, Chef chef2)
        {
            gameObject.SetActive(true);
            if (chef1.pScore > chef2.pScore)
                m_GameResult.text = chef1.pName + " Won!";
            else if (chef1.pScore < chef2.pScore)
                m_GameResult.text = chef2.pName + " Won!";
            else
                m_GameResult.text = "Match Tie!";
        }
    }
}
