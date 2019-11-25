using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [System.Serializable]
    public class PlayerScoreData
    {
        public List<int> scores;
        public PlayerScoreData()
        {
            scores = new List<int>();
        }
    }
    public class ScoreManager : MonoBehaviour
    {
        public Dictionary<string, PlayerScoreData> chefsScoreData = new Dictionary<string, PlayerScoreData>();

        [SerializeField] private Chef[] m_Chefs = default;

        private void Start()
        {
            for (int i = 0; i < m_Chefs.Length; ++i)
            {
                if (SaveManager.HasKey<string>(m_Chefs[i].pName))
                {
                    PlayerScoreData scoreData = SaveManager.LoadData<PlayerScoreData>(m_Chefs[i].pName);
                    if (scoreData != null)
                        chefsScoreData.Add(m_Chefs[i].pName, scoreData);
                }
            }
        }

        public void SetScore(string name, int score)
        {
            PlayerScoreData scoreData = null;

            if (!chefsScoreData.ContainsKey(name))
                chefsScoreData.Add(name, new PlayerScoreData());

            chefsScoreData.TryGetValue(name, out scoreData);
            scoreData.scores.Add(score);

            chefsScoreData[name] = scoreData;
            SaveManager.SaveData<PlayerScoreData>(name, scoreData);
        }

        public void Save()
        {
            SaveManager.CreateData();
        }
    }
}
