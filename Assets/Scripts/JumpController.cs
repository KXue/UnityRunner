using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour {
	public float m_JumpForce;
	public int m_MaxJumps;
	private bool m_IsGrounded = true;
    private bool m_CanJump = true;
    private bool m_JumpPressed = false;
    private bool m_JumpReleased = false;
    private int m_JumpNum = 0;
	private float m_GroundCastOffset = 0.2f;
	private Animator m_Animator;
	private Rigidbody m_RigidBody;
	private SphereCollider m_SphereCollider;
	public int Jumps{
		get{
			return m_MaxJumps - m_JumpNum;
		}
	}
	void Start () {
		m_Animator = GetComponent<Animator>();
		m_RigidBody = GetComponent<Rigidbody>();
        m_SphereCollider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		m_JumpPressed = Input.GetButton("Jump");
        m_JumpReleased = Input.GetButtonUp("Jump");
	}
	void FixedUpdate()
	{
		UpdateGroundState();
		//apply horizontal velocity
		Vector3 newVelocity = m_RigidBody.velocity;

		Jump(ref newVelocity);

		m_RigidBody.velocity = newVelocity;
	}
	private void UpdateGroundState()
	{
		Vector3 castPosition = transform.position + m_SphereCollider.center + new Vector3(0, -m_GroundCastOffset, 0);
		float castRadius = m_SphereCollider.radius;
		//1<<9 = layer 9 (Ground)
		m_IsGrounded = Physics.OverlapSphere(castPosition, castRadius, 1<<9).Length > 0;
		if(m_IsGrounded){
			m_JumpNum = 0;
		}
	}
	private void Jump(ref Vector3 outVelocity)
	{
		if (m_JumpPressed && m_CanJump && m_JumpNum < m_MaxJumps)
        {
			m_JumpNum++;
			m_Animator.SetTrigger("Jump");
			m_CanJump = false;
            outVelocity.y = m_JumpForce;
        }
        if (m_JumpReleased)
        {
			m_CanJump = true;
			if(outVelocity.y > 0){
                outVelocity.y = 0;
            }
        }
	}
}
