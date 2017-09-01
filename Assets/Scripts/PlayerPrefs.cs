using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefs {
	private static PlayerPrefs instance_;

	public static PlayerPrefs Instance(){
		if(instance_ == null){
			instance_ = new PlayerPrefs();
		}
		return instance_;
	}
}
