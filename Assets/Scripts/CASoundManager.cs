using UnityEngine;
using System.Collections.Generic;

/*
 * サウンド管理クラス
 */
public class CASoundManager : CASingletonMonoBehaviour<CASoundManager>{

	/* SE同時再生可能数 */
	const int SE_PLAY_MAX = 10;


	/* BGM用変数 */
	public AudioSource _bgmAudioSource = null;

	/* SE用変数 */
	public AudioSource _seAudioSource = null;


	/* リスト */
	private Dictionary<string, AudioClip> m_PoolAudioClip = new Dictionary<string, AudioClip>();
	private Dictionary<int, AudioSource> m_SeAudioSourceDict = new Dictionary<int, AudioSource> ();

	/* 再生中BGM ID */
	int m_PlayingBgmId = -1;


	/* SEファイル名 */	
	private static string[] m_SeFileNames = {
		"Sounds/START",
		"Sounds/PAUSE",
		"Sounds/achievement",
		"Sounds/bomb",
		"Sounds/garbage",
		"Sounds/reflect",
		"Sounds/iphonedefault_an",
	};

	/* SE ID */
	public enum SE
	{
		START = 0,
		PAUSE,
		ACHIEVEMENT,
		BOMB,
		GARBAGE,
		REFLECT,
		IPHONE,
	}

	/* BGM再生 */
	public void playBgm( int iBgmId , float iDelay = 0f){
		/* 同じBGMの場合 */
		if( m_PlayingBgmId == iBgmId ){
			if( _bgmAudioSource.isPlaying ){
				return;
			}
			else if( _bgmAudioSource.clip != null ){
				_bgmAudioSource.PlayDelayed(iDelay);
				return;
			}
		}
		if( 0 <= m_PlayingBgmId ){
			_bgmAudioSource.Stop();
		}

		string aFileName = getBgmResource(iBgmId);

		if (!m_PoolAudioClip.ContainsKey (aFileName)) {
			m_PoolAudioClip.Add (aFileName, loadAudioClip (aFileName));
		}

		if (m_PoolAudioClip [aFileName] == null) {
			Debug.Log ("------Null BGM : "+aFileName);
			return;
		}
		_bgmAudioSource.clip = m_PoolAudioClip[aFileName];
		_bgmAudioSource.loop = true;
		m_PlayingBgmId = iBgmId;
		_bgmAudioSource.PlayDelayed(iDelay);
	}

	/* SE再生 */
	public void playSe( SE iSeId ){
		if( m_SeAudioSourceDict.Count >= SE_PLAY_MAX ){ return; }
		int aSeId = (int)iSeId;
		//Debug.Log("SE = " + _seId );
		string aFileName = m_SeFileNames[aSeId];

		if (!m_PoolAudioClip.ContainsKey (aFileName)) {
			m_PoolAudioClip.Add (aFileName, loadAudioClip (aFileName));
		}

		if( m_SeAudioSourceDict.ContainsKey( aSeId ) ){
			m_SeAudioSourceDict [aSeId].Stop ();
		}else{
			AudioSource aSource = _seAudioSource.gameObject.AddComponent<AudioSource>();
			aSource.volume = _seAudioSource.volume;
			//
			m_SeAudioSourceDict.Add( aSeId, aSource );
		}
		// Play SE
		m_SeAudioSourceDict [aSeId].PlayOneShot( m_PoolAudioClip[aFileName] );
	}

	public void playSe( SE iSeId , float iDuration){
		if( m_SeAudioSourceDict.Count >= SE_PLAY_MAX ){ return; }
		int aSeId = (int)iSeId;

		string aFileName = m_SeFileNames[aSeId];

		if (!m_PoolAudioClip.ContainsKey (aFileName)) {
			m_PoolAudioClip.Add (aFileName, loadAudioClip (aFileName));
		}

		if( m_SeAudioSourceDict.ContainsKey( aSeId ) ){
			m_SeAudioSourceDict [aSeId].Stop ();
		}else{
			AudioSource source = _seAudioSource.gameObject.AddComponent<AudioSource>();
			source.volume = _seAudioSource.volume;
			source.clip = m_PoolAudioClip[aFileName];
			//
			m_SeAudioSourceDict.Add( aSeId, source );
		}
		// Play SE
		m_SeAudioSourceDict [aSeId].PlayDelayed (iDuration);
	}

    /* BGMストップ */
    public void stopBgm(){
		if( 0 <= m_PlayingBgmId ){
			_bgmAudioSource.Stop();
		}
	}
	
	/* BGMボリューム */
	public void setBgmVolume( float iVol ){
		if (_bgmAudioSource != null) {
			_bgmAudioSource.volume = iVol;
		}
	}
	
	/* SEボリューム */
	public void setSeVolume( float iVol ){
		if( _seAudioSource != null ){
			_seAudioSource.volume = iVol;
		}
		foreach (KeyValuePair<int, AudioSource> keyValue in m_SeAudioSourceDict) {
			keyValue.Value.volume = iVol;
		}
	}

	public void clearPoolAudioClip(){
		m_PoolAudioClip.Clear ();
	}

	private AudioClip loadAudioClip(string iFile_name)
	{
		return (AudioClip)Resources.Load (iFile_name);
	}

	private string getBgmResource(int iBgmID)
	{
		return "Sounds/bgm_" + iBgmID.ToString();
	}

	private void Update()
	{
		List<int> aIdList = new List<int>();
		// SE再生終了しているものを検索 
		foreach (KeyValuePair<int, AudioSource> keyValue in m_SeAudioSourceDict) {
			if (!keyValue.Value.isPlaying) {
				aIdList.Add(keyValue.Key);
			}
		}
		// 終了しているものを削除 
		for (int i = 0; i < aIdList.Count; ++i) {
			if (m_SeAudioSourceDict[aIdList[i]] != null) {
				Destroy(m_SeAudioSourceDict[aIdList[i]]);
			}
			m_SeAudioSourceDict.Remove(aIdList[i]);
		}

		aIdList.Clear();
	}
}
