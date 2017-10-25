using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingController : MonoBehaviour {

	public float m_killX;
	public float m_ScrollRate;
	private Rigidbody m_Body;
	// Use this for initialization
	void Start () 
	{
		m_Body = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		if(m_Body != null){
			Vector3 newVelocity = m_Body.velocity;
			newVelocity.x = m_ScrollRate * GameManager.Instance.Speed;
			m_Body.velocity = newVelocity;
		}
		else{
			Vector3 newPosition = transform.position;
			newPosition.x += Time.deltaTime * GameManager.Instance.Speed * m_ScrollRate;
			transform.position = newPosition;
		}
		if(transform.position.x <= m_killX)
		{
			Destroy(gameObject);
			// gameObject.SetActive(false);
		}
	}
}
