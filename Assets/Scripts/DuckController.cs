using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerDirection : sbyte { LEFT = -1, RIGHT = 1 };
public class DuckController : MonoBehaviour {
    public float m_MoveSpeed;
	public float m_JumpForce;
	public int m_MaxJumps;
	private PlayerDirection m_Direction = PlayerDirection.RIGHT;
    private bool m_IsGrounded = true;
    private bool m_CanJump = true;
    private bool m_JumpPressed = false;
    private bool m_JumpReleased = false;
    private int m_JumpNum = 0;
	private float m_Epsilon = 0.01f;
    private float m_GroundCastOffset = 0.1f;
    private float m_XAxis = 0f;
    private Animator m_Animator;
	private Rigidbody m_RigidBody;
	private SphereCollider m_SphereCollider;

    // Use this for initialization
    void Start () 
	{
        m_Animator = GetComponent<Animator>();
		m_RigidBody = GetComponent<Rigidbody>();
        m_SphereCollider = GetComponent<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		m_XAxis = Input.GetAxis("Horizontal");
        m_JumpPressed = Input.GetButton("Jump");
        m_JumpReleased = Input.GetButtonUp("Jump");
    }
	void FixedUpdate()
	{
		UpdateGroundState();
		//apply horizontal velocity
		Vector3 newVelocity = m_RigidBody.velocity;

		Move(ref newVelocity);
		Jump(ref newVelocity);

		m_RigidBody.velocity = newVelocity;
	}
	private void UpdateGroundState()
	{
		Vector3 castPosition = transform.position + m_SphereCollider.center + new Vector3(0, -m_GroundCastOffset, 0);
		float castRadius = m_SphereCollider.radius;
		//1<<9 = layer 9 (Ground)
		m_IsGrounded = Physics.OverlapSphere(castPosition, castRadius, 1<<9).Length > 0;
	}
	private void Move(ref Vector3 outVelocity){
        outVelocity.x = m_XAxis * m_MoveSpeed;
        m_Animator.SetFloat("Speed", Mathf.Abs(outVelocity.x));
        if ((float)m_Direction * m_XAxis < 0)
        {
            Flip();
        }
	}
	private void Jump(ref Vector3 outVelocity)
	{
		if (m_JumpPressed && m_IsGrounded && m_CanJump)
        {
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
	private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_Direction = (PlayerDirection)((sbyte)m_Direction * -1);
		m_Animator.SetBool("FacingLeft", m_Direction == PlayerDirection.LEFT);
        // Multiply the player's x local scale by -1.
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y * -1, 0);
    }
}

