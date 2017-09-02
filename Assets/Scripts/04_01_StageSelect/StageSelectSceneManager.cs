using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectSceneManager : MonoBehaviour {

	public void OnPushStage1Button()
	{
		PlayerPrefs.SetInt(PlayerPrefsKey.SELECTED_STAGE_KEY, 1);
		ChangeScene();
	}
	public void OnPushStage2Button()
	{
		PlayerPrefs.SetInt(PlayerPrefsKey.SELECTED_STAGE_KEY, 2);
		ChangeScene();
	}
	public void OnPushStage3Button()
	{
		PlayerPrefs.SetInt(PlayerPrefsKey.SELECTED_STAGE_KEY, 3);
		ChangeScene();
	}
	public void OnPushStage4Button()
	{
		PlayerPrefs.SetInt(PlayerPrefsKey.SELECTED_STAGE_KEY, 4);
		ChangeScene();
	}
	public void OnPushStage5Button()
	{
		PlayerPrefs.SetInt(PlayerPrefsKey.SELECTED_STAGE_KEY, 5);
		ChangeScene();
	}
	public void OnPushStage6Button()
	{
		PlayerPrefs.SetInt(PlayerPrefsKey.SELECTED_STAGE_KEY, 6);
		ChangeScene();
	}
	public void OnPushStage7Button()
	{
		PlayerPrefs.SetInt(PlayerPrefsKey.SELECTED_STAGE_KEY, 7);
		ChangeScene();
	}
	private void ChangeScene()
	{
		SceneManager.LoadScene("04_Game'");
	}
}
