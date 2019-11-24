using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefStats : MonoBehaviour
{
    [SerializeField] private TextMesh m_TimeTextMesh;
    [SerializeField] private TextMesh m_ScoreTextMesh;

    public string pTimeText
    {
        get
        {
            return m_TimeTextMesh.text;
        }
        set
        {
            m_TimeTextMesh.text = value;
        }
    }

    public string pScoreText
    {
        get
        {
            return m_ScoreTextMesh.text;
        }
        set
        {
            m_ScoreTextMesh.text = value;
        }
    }
}
