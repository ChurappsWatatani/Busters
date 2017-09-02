using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour {
	[SerializeField] private bool _showCreditButton;
	[SerializeField] private bool _showSecretButton;
	[SerializeField] private GameObject _creditButton;
	[SerializeField] private GameObject _secretButton;
	void Start()
	{
		if(PlayerPrefs.GetInt(PlayerPrefsKey.CREDIT_KEY) == 1 || _showCreditButton)
		{
			_creditButton.SetActive(true);
		}
		if(PlayerPrefs.GetInt(PlayerPrefsKey.SECRET_KEY) == 1 || _showSecretButton)
		{
			_secretButton.SetActive(true);
		}
	}
	public void OnPushStartButton()
	{
		SceneManager.LoadScene("04_01_StageSelect");
	}

	public void OnPushCreditButton()
	{
		SceneManager.LoadScene("03_Credit");
	}
	public void OnPushSecretButton()
	{
		SceneManager.LoadScene("02_Secret");
	}
}
