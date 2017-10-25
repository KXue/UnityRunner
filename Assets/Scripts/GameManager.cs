using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour {
	public float m_SpeedUpTime = 10.0f;
	public float m_MaxSpeed = 3.5f;
	public GameObject m_Player;
	private float m_SpeedUpTimer = 0.0f;
	private float m_Speed = 1.0f;

	private static GameManager instance;
    // Static singleton property
    public static GameManager Instance
    {
        get {
			return instance ?? (instance = new GameObject("Singleton").AddComponent<GameManager>()); 
		}
    }
	void Awake()
	{
		if(instance != null && instance != this){
			Destroy(gameObject);
		}
		instance = this;
	}
	public float Speed {
		get{
			return m_Speed;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate()
	{
		m_SpeedUpTimer += Time.deltaTime;
		if(m_SpeedUpTimer >= m_SpeedUpTime){
			SpeedUp();
			m_SpeedUpTimer = 0.0f;
		}
	}
	void SpeedUp(){
		m_Speed *= 1.1f;
		m_Speed = Mathf.Min(m_MaxSpeed, m_Speed);
	}
}
