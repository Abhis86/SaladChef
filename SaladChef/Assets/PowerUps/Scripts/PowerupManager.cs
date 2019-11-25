using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

namespace SaladChef
{
    public class PowerupManager : AutoInstantiateSingleton<PowerupManager>
    {
        [SerializeField] ChefView[] m_Chef = default;
        [SerializeField] private PowerupsData m_PowerupsData = default;
        [SerializeField] private Collider2D m_Boundary = default;

        Vector2 mBoundaryExtent;
        List<GameObject> mPowerups = new List<GameObject>();

        protected override void Start()
        {
            base.Start();
            mBoundaryExtent = m_Boundary.bounds.extents;
        }

        public void GenerateRandomPowerup(Chef chef)
        {
            Powerup powerup = m_PowerupsData.GetRandomPowerup();
            powerup.transform.position = GetRandomFreePoint(10, new Vector2[] { m_Chef[0].transform.position, m_Chef[1].transform.position }, 1, mBoundaryExtent.x, mBoundaryExtent.y);
            mPowerups.Add(powerup.gameObject);
            powerup.pChef = chef;
        }

        private Vector2 GetRandomFreePoint(int maxTries, Vector2[] avoidPositions, float sideLength, float maxXPos, float maxYPos)
        {
            int count = 0;
            while (count < maxTries)
            {
                float xPos = UnityEngine.Random.Range(-maxXPos, maxXPos);
                float yPos = UnityEngine.Random.Range(-maxYPos, maxYPos);

                bool isGood = true;

                for (int i = 0; i < avoidPositions.Length && isGood; i++)
                {
                    if (avoidPositions[i].x < xPos + sideLength && avoidPositions[i].x + sideLength > xPos &&
                        avoidPositions[i].y < yPos + sideLength && avoidPositions[i].y + sideLength > yPos)
                        isGood = false;
                }
                if (isGood)
                    return new Vector2(xPos, yPos);
                count++;
            }

            return Vector2.zero;
        }

        public void Reset()
        {
            foreach(GameObject obj in mPowerups)
            {
                if (obj != null)
                    Destroy(obj);
            }

            mPowerups.Clear();
        }
    }
}
