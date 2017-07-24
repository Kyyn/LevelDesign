using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderClap : MonoBehaviour 
{
    public AudioClip clip;
    bool canFlicker = true;
    Light _light;
    AudioSource audioSource;
	// Use this for initialization
	void Start () 
	{
        _light = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        StartCoroutine(Flicker());
	}

    IEnumerator Flicker()
    {
        if (canFlicker)
        {
            canFlicker = false;
            audioSource.PlayOneShot(clip);
            _light.enabled = true;

            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));

            _light.enabled = false;

            yield return new WaitForSeconds(Random.Range(0.1f, 5.0f));

            canFlicker = true;
        }
    }
}
