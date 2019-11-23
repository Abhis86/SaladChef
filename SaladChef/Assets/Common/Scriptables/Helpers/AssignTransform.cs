using UnityEngine;

namespace Framework.Scriptables.Helper
{
    public class AssignTransform : MonoBehaviour
    {
        [SerializeField] private TransformProperty m_TransformProperty = default;

        private void OnEnable()
        {
            m_TransformProperty.value = transform;
            Destroy(this);
        }
    }
}
