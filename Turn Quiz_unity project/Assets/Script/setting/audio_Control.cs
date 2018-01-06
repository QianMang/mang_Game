using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_Control : MonoBehaviour {

	public TweenScale sound_on_btn;
	public TweenScale sound_off_btn;
	[HideInInspector]
	public int audio_On;

	void Start()
	{
		audio_On = GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().getSound ();
		if (GameObject.FindWithTag ("level").GetComponent<Transform>().name =="menu" )
			setAudio ();
		else
			setAudioInGame ();
	}
	public void change_audio()
	{
		audio_On = audio_On==1?0:1;
		print (audio_On);
		setAudio ();
		GameObject.Find ("Main Camera").GetComponent<_playerPrefs> ().saveSound (audio_On);

	}
	void setAudio()
	{
		if (audio_On == 0) {
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().volume = 0;
			sound_on_btn.PlayForward ();
			sound_off_btn.PlayForward ();
		} else if(audio_On==1) {
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().volume=1;
			sound_on_btn.PlayReverse ();
			sound_off_btn.PlayReverse ();
		}
	}
	void setAudioInGame()
	{
		if (audio_On == 0) {
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().volume = 0;

		} else {
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().volume = 1;

		}

	}


}
