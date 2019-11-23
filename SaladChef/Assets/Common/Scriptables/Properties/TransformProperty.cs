using UnityEngine;

namespace Framework.Scriptables
{
    [CreateAssetMenu(menuName = "Properties/Transform")]
    public class TransformProperty : ScriptableObject
    {
        public Transform value;

        public void Set(Transform v)
        {
            value = v;
        }

        public void Set(TransformProperty v)
        {
            value = v.value;
        }

        public void Clear()
        {
            value = null;
        }
    }
}
