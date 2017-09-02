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
	private List<GameObject> _GarbageObjects;

	[SerializeField]
	private List<Sprite> _GarbageSprites;

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

			Sprite aGarbageSprite = null;
			int aPoint = 0;

			Debug.Log (item.Key);

			switch (item.Key) {

			case  "g_001":
				aGarbageSprite = _GarbageSprites [1];
				aPoint =  _GarbageObjects [1].GetComponent<GarbageController>().point;
				break;

			case  "g_002":
				aGarbageSprite = _GarbageSprites [2];
				aPoint =  _GarbageObjects [2].GetComponent<GarbageController>().point;
				break;

			case  "g_003":
				aGarbageSprite = _GarbageSprites [3];
				aPoint =  _GarbageObjects [3].GetComponent<GarbageController>().point;
				break;

			case  "g_004":
				aGarbageSprite = _GarbageSprites [4];
				aPoint =  _GarbageObjects [4].GetComponent<GarbageController>().point;
				break;

			case  "g_005":
				aGarbageSprite = _GarbageSprites [5];
				aPoint =  _GarbageObjects [5].GetComponent<GarbageController>().point;
				break;
			}

			aPoint =  GameManager.instance.busterGarbagePoints[item.Key];

			_ResutPoints[i].setPoint (aGarbageSprite, item.Value.ToString(),(aPoint * item.Value).ToString());
		
			i++;
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
