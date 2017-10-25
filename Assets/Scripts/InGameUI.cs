using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {
	private ScoreKeeper m_ScoreKeeper;
	private JumpController m_JumpController;
	public Text m_ScoreText;
	public Text m_HighScoreText;
	public Text m_MultiplierText;
	public Text m_JumpText;
	// Use this for initialization
	void Start () {
		m_ScoreKeeper = GameManager.Instance.m_Player.GetComponent<ScoreKeeper>();
		m_JumpController = GameManager.Instance.m_Player.GetComponent<JumpController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(m_ScoreKeeper != null){
			m_ScoreText.text = "Score: " + m_ScoreKeeper.Score;
			m_HighScoreText.text = "HighScore: " + m_ScoreKeeper.HighScore;
			m_MultiplierText.text = "Multiplier: x" + m_ScoreKeeper.Multiplier;
			m_JumpText.text = "Jumps: " + m_JumpController.Jumps;
		}
	}
}
