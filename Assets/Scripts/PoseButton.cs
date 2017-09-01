using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoseButton : MonoBehaviour {

	public void OnPushPoseButton()
	{
		//ゲームを中断する処理とかが必要ならここで呼ぶ

		//ポーズシーンを追加でLoadする
		SceneManager.LoadScene("05_Pose", LoadSceneMode.Additive);
	}
}
