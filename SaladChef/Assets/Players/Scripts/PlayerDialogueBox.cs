using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    public class PlayerDialogueBox : MonoBehaviour
    {
        [SerializeField] private TextMesh m_TextMesh = default;

        public void ShowDialogBox(string message)
        {
            gameObject.SetActive(true);
            m_TextMesh.text = message;
        }

        public void HideDialogBox()
        {
            gameObject.SetActive(false);
        }
    }
}
