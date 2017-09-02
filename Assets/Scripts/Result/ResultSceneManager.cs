using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSceneManager : MonoBehaviour 
{
	[SerializeField]
	private Button _BtnReplay;
	[SerializeField]
	private Button _BtnToTitle;
	[SerializeField]
	private Text _TxtScore;

	void Start()
	{
		_BtnReplay.onClick.AddListener (OnPushReplayButton);
		_BtnToTitle.onClick.AddListener (OnPushToTitletButton);
	}

	public void OnPushReplayButton()
	{
		SceneManager.LoadScene("04_Game");
	}

	public void OnPushToTitletButton()
	{
		SceneManager.LoadScene("01_Title");
	}
}
