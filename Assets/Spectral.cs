using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectral : MonoBehaviour {
	public AudioProcessor processor;
	public List<GameObject> cyls;
	public float amp = 1f;

	void Start() {
		processor.onBeat.AddListener(onOnbeatDetected);
		processor.onSpectrum.AddListener(onSpectrum);
	}

	//this event will be called every time a beat is detected.
	//Change the threshold parameter in the inspector
	//to adjust the sensitivity
	void onOnbeatDetected() {
		Debug.Log("Beat!!!");
	}

	//This event will be called every frame while music is playing
	void onSpectrum(float[] spectrum) {
		//The spectrum is logarithmically averaged
		//to 12 bands

		for (int i = 0; i < spectrum.Length; ++i) {
			//Vector3 start = new Vector3(i, 0, 0);
			//Vector3 end = new Vector3(i, spectrum[i], 0);

			GameObject cur = cyls[i];
			Vector3 scale = cur.transform.localScale;
			scale.y = spectrum[i] * amp;
			cur.transform.localScale = scale;

			//Debug.Log(i + " - " + spectrum[i]);
			//Debug.DrawLine (start, end);
		}
	}
}
