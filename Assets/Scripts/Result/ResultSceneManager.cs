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

			aGarbageSprite = GameManager.instance.busterGarbageSprite[item.Key];
			aPoint =  GameManager.instance.busterGarbagePoints[item.Key];

			_ResutPoints[i].setPoint (aGarbageSprite, item.Value.ToString(),(aPoint * item.Value).ToString());
		
			i++;
			if (i >= 4) {
				break;
			}
		}

		//おまけ解放
		int aTotalPoint = PlayerPrefs.GetInt(PlayerPrefsKey.TOTAL_POINT ,0);
		aTotalPoint += GameManager.instance.point;
		PlayerPrefs.SetInt(PlayerPrefsKey.TOTAL_POINT, aTotalPoint);

		Debug.Log ("aTotalPoint " + aTotalPoint);

		if (aTotalPoint > 3000) {
			//3000以上でクレジット解放
			PlayerPrefs.SetInt(PlayerPrefsKey.CREDIT_KEY, 1);

		} 
		if (aTotalPoint > 5000) {
			//5000以上でひみつの部屋解放
			PlayerPrefs.SetInt(PlayerPrefsKey.SECRET_KEY, 1);
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
