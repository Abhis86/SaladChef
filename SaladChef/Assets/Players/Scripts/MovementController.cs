using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaladChef
{
    [System.Serializable]
    public class MovementControlInfo
    {
        [SerializeField] private float m_Speed = default;
        [SerializeField] private string m_HorizontalMoveInputAxis = default;
        [SerializeField] private string m_VerticalMoveInputAxis = default;

        public float pSpeed { get => m_Speed; set => m_Speed = value; }
        public string pHorizontalMoveInputAxis { get => m_HorizontalMoveInputAxis; }
        public string pVerticalMoveInputAxis { get => m_VerticalMoveInputAxis; }
    }

    public class MovementController : MonoBehaviour
    {
        public MovementControlInfo info;
        public BoxCollider2D boundary = default;
        public Vector2 playerViewSize = default;

        private Vector2 mMoveVelocity;
        private Transform mTransform;

        private Bounds mBounds;

        public void DoSetup()
        {
            mTransform =transform;
            if (boundary != null)
                mBounds = boundary.bounds;
        }


        private void Update()
        {
            mMoveVelocity = new Vector2(Input.GetAxisRaw(info.pHorizontalMoveInputAxis), Input.GetAxisRaw(info.pVerticalMoveInputAxis)).normalized * info.pSpeed;
            var pos = Clamp((Vector2)mTransform.position + mMoveVelocity * Time.deltaTime);
            mTransform.position = pos;
        }


        private Vector2 Clamp(Vector2 point)
        {
            point.x = Mathf.Clamp(point.x, mBounds.min.x + playerViewSize.x, mBounds.max.x - playerViewSize.x);
            point.y = Mathf.Clamp(point.y, mBounds.min.y + playerViewSize.y, mBounds.max.y - playerViewSize.y);
            return point;
        }
    }
}
