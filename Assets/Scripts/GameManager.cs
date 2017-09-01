using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
	public int point = 0;
	public Dictionary<GameObject, int> busterGarbages = new Dictionary<GameObject, int>();

	private static GameManager instance_;

	public static GameManager Instance()
	{
		if (instance_ == null) {
			instance_ = new GameManager();
		}
		return instance_;
	}

	public void AddGarbages(GameObject obj)
	{
		if (busterGarbages.ContainsKey(obj)) {
			busterGarbages[obj]++;
		}
		else {
			busterGarbages.Add(obj, 1);
		}
	}
}
