using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {
    public Transform player;
    public int numberOfStartingPlatforms;
   //clone this object in every 50 meteres
    public Vector3 platformSpawnPoint;
    public GameObject [] platforms;
    public float destroyTime = 5f;
    //Unity custom funcitons
    void Start()
    {
        int counter = 0;
        while (counter < numberOfStartingPlatforms)
        {
            CreateNextPlatform();
            counter = counter + 1;
        }
    }
    int PP;
    int lastPP = 0;
	void Update ()
    {
        PP = (int)(player.position.z / 50);
        if(PP > lastPP)
        {
            CreateNextPlatform();
        }
        lastPP = PP;
    }
    //my custom functions
    void CreateNextPlatform()
    {
        Debug.Log("Creating Platform");

        platformSpawnPoint.z = platformSpawnPoint.z + 50f;

        int platformChooser = Random.Range(0, platforms.Length);

        GameObject clone;
        clone = Instantiate(platforms[platformChooser]);

        clone.transform.position = platformSpawnPoint;
        Destroy(clone, destroyTime);
    }
}
