using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelMap : MonoBehaviour {

    Location[,] locations;
    
    LevelMap (string composition)
    {
        if (composition == "comp1")
            locations = new Location[5,5];
        locations[0, 0] = "scene1";
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
