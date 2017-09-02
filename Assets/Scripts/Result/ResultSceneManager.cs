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
	[SerializeField]
	private List<ResutPoint> _ResutPoints = new List<ResutPoint>();

	[SerializeField]
	private List<Sprite> _GarbageSprits;

	void Start()
	{
		_BtnReplay.onClick.AddListener (OnPushReplayButton);
		_BtnToTitle.onClick.AddListener (OnPushToTitletButton);

		//TODO 
		initialize ();
	}

	public void initialize()
	{
		reset ();

		_TxtScore.text = GameManager.instance.point.ToString();

		int i = 0;
		foreach (var item in GameManager.instance.busterGarbages) {
			_ResutPoints[i].setPoint (setGarbageData(item.Key), item.Value.ToString(),setGarbagePoint(item.Key).ToString());
			i++;
		}

		// TODO 得点がしきい値を超えて、ひみつ画面とクレジット画面が開放
		if (GameManager.instance.point > 1000000000) {
			PlayerPrefs.SetInt (PlayerPrefsKey.CREDIT_KEY, 1);
			PlayerPrefs.SetInt (PlayerPrefsKey.SECRET_KEY, 1);
		}
	}

	private Sprite setGarbageData(string iGarbageName)
	{
		switch (iGarbageName) {

		case  "Garbage1":
			return _GarbageSprits [1];
			break;

		case  "Garbage2":
			return _GarbageSprits [2];
			break;

		case  "Garbage3":
			return _GarbageSprits [3];
			break;


		default:
			return _GarbageSprits [1];
			break;
		}
	}

	private int setGarbagePoint(string iGarbageName)
	{
		switch (iGarbageName) {

		case  "Garbage1":
			return 100;
			break;

		case  "Garbage2":
			return 150;
			break;

		case  "Garbage3":
			return  0;
			break;

		default:
			return  0;
			break;
		}
	}


	private void reset()
	{
		_TxtScore.text = "0";
		foreach (ResutPoint aResutPoint in _ResutPoints) {
			aResutPoint.setPoint (null, "", "");
		}
	}


	public void OnPushReplayButton()
	{
		SceneManager.LoadScene("04_Game");
		GameManager.instance.gameState = GameManager.State.Start;
	}

	public void OnPushToTitletButton()
	{
		SceneManager.LoadScene("01_Title");
	}



}
