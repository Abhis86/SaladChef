using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    public float m_Speed;
    public string m_HorizontalMoveInputAxis = "Horizontal";
    public string m_VerticalMoveInputAxis = "Vertical";

    private Vector2 mMoveVelocity;
    private Rigidbody2D mRigidbody2D;

    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mMoveVelocity = new Vector2(Input.GetAxisRaw(m_HorizontalMoveInputAxis), Input.GetAxisRaw(m_VerticalMoveInputAxis)).normalized * m_Speed;
    }

    private void FixedUpdate()
    {
        var pos = mRigidbody2D.position + mMoveVelocity * Time.fixedDeltaTime;
        mRigidbody2D.MovePosition(pos);
    }
}
