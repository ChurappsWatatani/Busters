using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : CASingletonMonoBehaviour<GameManager> {
	const int MAX_PLAY_COUNT = 5;

	public enum State
	{
		Start,
		Playing,
		GameEnd,
		EndAnimation,
		Result
	}
	
	public int point = 0;
	public int playCount = 0;
	public PlayerController player;
	public List<GameObject> garbages = new List<GameObject>();
	public Dictionary<string, int> busterGarbages = new Dictionary<string, int>();
	public State gameState = State.Start;

	public void Start()
	{
		Debug.Log("Start");
		Initialize();
	}

	public void Update()
	{
		if (gameState == State.GameEnd) {
			gameState = State.EndAnimation;
			Debug.Log("Game EndAnimation");
		}
	}

	public void Initialize()
	{
		point = 0;
		playCount = 0;
		gameState = State.Start;

		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		garbages = GameObject.FindGameObjectsWithTag("Garbage").ToList();
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
			gameState = State.GameEnd;
		}
	}

	public bool CheckEndPlayCount()
	{
		if (MAX_PLAY_COUNT <= playCount) {
			gameState = State.GameEnd;
		}
		return (MAX_PLAY_COUNT <= playCount);
	}
}
