using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : CASingletonMonoBehaviour<GameManager> {
	const int MAX_PLAY_COUNT = 5;

	public enum State
	{
		None,
		Start,
		StartAnimation,
		Playing,
		GameEnd,
		EndAnimation,
		Result
	}
	
	public int point = 0;
	public int playCount = 0;
	public Dictionary<string, int> busterGarbages = new Dictionary<string, int>();
	public State gameState = State.None;

	protected int stageCount = 1;
	protected StageManager stageManager;
	protected PlayerController player;
	protected List<GameObject> garbages = new List<GameObject>();
	protected StageAnimationController animator;

	public void Start()
	{
		gameState = State.Start;
	}

	public void Update()
	{
		if (gameState == State.Start) {
			Initialize();
		}
	}

	public void Initialize()
	{
		point = 0;
		playCount = 0;
		gameState = State.Start;

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		animator = GameObject.FindGameObjectWithTag("StageAnimation").GetComponent<StageAnimationController>();
		stageManager = GameObject.FindGameObjectWithTag("StageManager").GetComponent<StageManager>();

		stageCount = PlayerPrefs.GetInt(PlayerPrefsKey.SELECTED_STAGE_KEY, 1);
		stageCount = 6;
		var stageParent = GameObject.FindGameObjectWithTag("Stage");
		var obj = Instantiate(Resources.Load("Prefabs/Stage" + stageCount)) as GameObject;
		obj.transform.SetParent(stageParent.transform);
		obj.transform.localScale = Vector3.one;
		obj.transform.localPosition = new Vector2(0, -57);
		var stage = obj.GetComponent<StageController>();
		stageManager.stageText.text = "ステージ" + stageCount;
		stageManager.stageNameText.text = stage.stageName;

		//ステージ内のゴミリスト取得
		garbages = GameObject.FindGameObjectsWithTag("Garbage").ToList();

		if (stageCount < 8) {
			GameStart();
		}
		else {
			gameState = State.StartAnimation;
			animator.EnterWarning();
		}
	}

	public void GameStart()
	{
		gameState = State.Playing;
	}

	public void Pause(bool enable)
	{
		if (enable) {
			Time.timeScale = 0;
		}
		else {
			Time.timeScale = 1;
		}
	}

	public void AddBusgerGarbages(GameObject obj)
	{
		if (busterGarbages.ContainsKey(obj.name)) {
			busterGarbages[obj.name]++;
		}
		else {
			busterGarbages.Add(obj.name, 1);
		}
		garbages.Remove(obj);
		if (garbages.Count <= 0) {
			Debug.Log("ゴミ終了");
			GameEnd();
		}
	}

	public bool CheckEndPlayCount()
	{
		if (MAX_PLAY_COUNT <= playCount) {
            GameEnd();
			Debug.Log("残機なし");
		}
		return (MAX_PLAY_COUNT <= playCount);
	}

	public void ExitEndAnimation()
	{
		gameState = State.Result;
		SceneManager.LoadScene("06_Result");
	}

	protected void GameEnd()
	{
		Debug.Log("GameEnd");
		gameState = State.GameEnd;
		animator.EnterEndAnimation();
	}
}
