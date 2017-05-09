using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasher : MonoBehaviour {

    public Behaviour bulb;
    public float time = 0.5f;

	void Start () {
        StartCoroutine(Flash(time));
	}

    IEnumerator Flash(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            bulb.enabled = !bulb.enabled;
        }
    }	
}
