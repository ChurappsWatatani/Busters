﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsKey {

	//クレジット画面をオープンするかどうかのフラグを格納する
	public static string CREDIT_KEY = "Credit";
	//ひみつ画面をオープンするかどうかのフラグを格納する
	public static string SECRET_KEY = "Secret";
	//ユーザが選択したステージ
	public static string SELECTED_STAGE_KEY = "SelectedStage";


	// private static PlayerPrefs instance_;

	// public static PlayerPrefs Instance(){
	// 	if(instance_ == null){
	// 		instance_ = new PlayerPrefs();
	// 	}
	// 	return instance_;
	// }
}