using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerDirection : sbyte { LEFT = -1, RIGHT = 1 };
public class DuckController : MonoBehaviour {
    public float m_MoveSpeed;
	private PlayerDirection m_Direction = PlayerDirection.RIGHT;
	private float m_Epsilon = 0.01f;
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
    }
	void FixedUpdate()
	{
		//apply horizontal velocity
		Vector3 newVelocity = m_RigidBody.velocity;

		Move(ref newVelocity);

		m_RigidBody.velocity = newVelocity;
	}

	private void Move(ref Vector3 outVelocity){
        if(Mathf.Abs(m_XAxis) > m_Epsilon){
			outVelocity.x = m_XAxis * m_MoveSpeed;
			m_Animator.SetFloat("Speed", Mathf.Abs(outVelocity.x));
		}
        if ((float)m_Direction * m_XAxis < 0)
        {
            Flip();
        }
	}
	private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_Direction = (PlayerDirection)((sbyte)m_Direction * -1);
        // Multiply the player's x local scale by -1.
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y * -1, 0);
    }
}

