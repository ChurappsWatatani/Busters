using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour {

	public void OnPushStartButton()
	{
		SceneManager.LoadScene("Game");
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
