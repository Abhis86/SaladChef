using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

namespace SaladChef
{
    public class UIHighScore : UIBehaviour
    {
        [SerializeField] private UIScoreItem m_Template = default;
        [SerializeField] private Text[] m_ChefName = default;
        [SerializeField] private RectTransform[] m_Contents = default;

        public void Show(Dictionary<string, PlayerScoreData> chefsScoreData)
        {
            int count = 0;
            foreach (KeyValuePair<string, PlayerScoreData> chefScoreData in chefsScoreData)
            {
                m_ChefName[count].text = chefScoreData.Key.ToString();
                m_Contents[count].transform.ClearChildren();
                List<int> scores = chefScoreData.Value.scores.OrderByDescending(ele => ele).ToList();
                for (int i = 0; i < scores.Count && i < 10; ++i)
                {
                    UIScoreItem scoreItem = Instantiate<UIScoreItem>(m_Template, m_Contents[count]);
                    scoreItem.text.text = scores[i].ToString();
                }

                ++count;
            }
        }
    }
}
