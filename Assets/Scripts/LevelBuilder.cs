using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {
    public Transform player;
    public Vector3 lastPLatformPosition;
	void Update ()
    {
        float pp = (int)player.position.z / 50;
	}
}
