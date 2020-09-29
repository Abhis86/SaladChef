using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLayout : MonoBehaviour
{
    [SerializeField] private bool m_IsVertical = default;
    [SerializeField] private Vector2 m_localScale = Vector2.one;
    [SerializeField] private float m_Spacing = 0;

    private int mChildCount = 0;

    private void LateUpdate()
    {
        if (mChildCount != transform.childCount)
        {
            mChildCount = transform.childCount;
            SetChildrenSize();
            SetChildrenPosition();
        }
    }

    private void SetChildrenSize()
    {
        for (int i = 0; i < mChildCount; ++i)
            transform.GetChild(i).localScale = m_localScale;
    }

    private void SetChildrenPosition()
    {
        float stratPos = 0;
        float size = 0;

        Vector2 childPosition = Vector2.zero;

        if (m_IsVertical)
        {
            size = m_localScale.y + m_Spacing;
            stratPos = -FirstChildPosition(mChildCount, size);
            for (int i = 0; i < transform.childCount; ++i)
            {
                childPosition.Set(0, stratPos + size * i);
                transform.GetChild(i).localPosition = childPosition;
            }
        }
        else
        {
            size = m_localScale.x + m_Spacing;
            stratPos = -FirstChildPosition(mChildCount, size);
            for (int i = 0; i < transform.childCount; ++i)
            {
                childPosition.Set(stratPos + size * i, 0);
                transform.GetChild(i).localPosition = childPosition;
            }
        }
    }

    private static float FirstChildPosition(int count, float size)
    {
        return (size * (int)(count / 2) - (count % 2 == 0 ? size * 0.5f : 0));
    }

    public void ForcedUpdate()
    {
        mChildCount = transform.childCount;
        SetChildrenSize();
        SetChildrenPosition();
    }

#if UNITY_EDITOR
    protected void OnValidate()
    {
        //if (!Application.isPlaying)
        //{
            mChildCount = transform.childCount;
            SetChildrenSize();
            SetChildrenPosition();
       // }
    }
#endif
}
