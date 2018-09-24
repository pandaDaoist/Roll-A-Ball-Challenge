using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secretPassage : MonoBehaviour {
    public Transform startPos, endPos;
    public bool repeatable = false;
    public float speed = 1.0f;

    float startTime, totalDistance;

	// Use this for initialization
	IEnumerator Start () {
        startTime = Time.time;
        totalDistance = Vector3.Distance(startPos.position, endPos.position);
        while(repeatable)
        {
            yield return RepeeatLerp(startPos.position, endPos.position, 3.0f);
            yield return RepeeatLerp(endPos.position, startPos.position, 3.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(!repeatable)
        {
            float currentDuration = (Time.time - startTime) * speed;
            float journeyFraction = currentDuration / totalDistance;
            this.transform.position = Vector3.Lerp(startPos.position, endPos.position, journeyFraction);
        }
	}
    public IEnumerator RepeeatLerp(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while(i  < 1.0f)
        {
            i += Time.deltaTime * rate;
            this.transform.position = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
