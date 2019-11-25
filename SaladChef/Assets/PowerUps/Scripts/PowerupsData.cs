using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [CreateAssetMenu(menuName = "PowerupsData")]
    public class PowerupsData : ScriptableObject
    {
        [SerializeField] private Powerup[] m_Powerups = default;

        public Powerup GetRandomPowerup()
        {
            return Instantiate<Powerup>(m_Powerups[Random.Range(0, m_Powerups.Length)]);
        }
    }
}
