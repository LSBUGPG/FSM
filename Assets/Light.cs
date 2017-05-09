using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour {

    Material material;

	void Awake ()
    {
        material = GetComponent<Renderer>().material;
	}

    void OnEnable()
    {
        material.SetColor("_EmissionColor", material.color);
    }

    void OnDisable()
    {
        material.SetColor("_EmissionColor", Color.black);
    }
}
