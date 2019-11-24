using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Transform m_Bar = default;
    [SerializeField] float m_DefaultProgress = default;
    private float mProgress = 0;

    private void Awake()
    {
        mProgress = m_DefaultProgress;
        pProgress = mProgress;
    }

    public float pProgress
    {
        get
        {
            return mProgress;
        }
        set
        {
            mProgress = value;
            m_Bar.localScale = new Vector3(mProgress, m_Bar.localScale.y, 1);
        }
    }
}
