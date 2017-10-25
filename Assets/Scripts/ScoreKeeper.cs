using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {
	private int m_Score = 0;
	private int m_ScoreMultiplier = 1;
	private float m_ScoreTimer = 0;
	private int m_HighScore = 0;
	private int m_PastHighScore = 0;
	public int Score{
		get{
			return m_Score;
		}
	}
	public int Multiplier{
		get{
			return m_ScoreMultiplier;
		}
	}
	public int HighScore{
		get{
			return m_HighScore;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		m_ScoreTimer += Time.deltaTime;
		if(m_ScoreTimer >= 1.0f){
			m_ScoreTimer = 0;
			TickScore();
		}
	}
	void TickScore(){
		m_Score += m_ScoreMultiplier;
		UpdateHighScore();
	}
	void UpdateHighScore(){
		if(m_Score > m_HighScore){
			m_HighScore = m_Score;
		}
	}
	public void AddScore(int amount = 1){
		m_Score += amount;
		UpdateHighScore();
	}
	public void AddMultiplier(int amount = 1){
		m_ScoreMultiplier += amount;
	}
}
