using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static void ClearChildren(this Transform transform)
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
