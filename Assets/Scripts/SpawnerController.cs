using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {
	public GameObject[] m_SpawnPrefab;
	public Vector3 m_SpawnPositionOffset;
	public float m_SpawnTimeMean = 0.7f;
	public float m_SpawnTimeVariance = 0.2f;
	public float m_SpawnVerticalVariance = 1.0f;
	private float m_SpawnTime;
	private float m_SpawnTimer = 0.0f;
	void Awake () {
		CalculateSpawnTime();
	}
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		m_SpawnTimer += Time.deltaTime * GameManager.Instance.Speed;
		if(m_SpawnTimer >= m_SpawnTime){
			m_SpawnTimer = 0f;
			SpawnSheep();
			CalculateSpawnTime();
		}
	}
	void CalculateSpawnTime(){
		m_SpawnTime = m_SpawnTimeMean + Random.Range(-m_SpawnTimeVariance, m_SpawnTimeVariance);
	}
	Vector3 VerticalVariance(){
		return new Vector3(0, Random.Range(-m_SpawnVerticalVariance, m_SpawnVerticalVariance), 0);
	}
	GameObject GetRandomObject(){
		return m_SpawnPrefab[(int)Random.Range(0, m_SpawnPrefab.Length - 1)];
	}
	void SpawnSheep()
	{
		GameObject spawned = Instantiate(GetRandomObject());
		Vector3 spawnVariance = VerticalVariance() + m_SpawnPositionOffset;
		spawned.transform.position = transform.position + spawnVariance;
	}
}
