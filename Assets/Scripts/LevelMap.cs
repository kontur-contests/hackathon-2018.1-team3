using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelMap : MonoBehaviour {


    MyLocation[,] locations;

    LevelMap(string composition)
    {
        if (composition == "comp1")
        {
            locations = new MyLocation[5, 5];
            locations[0, 0] = new MyLocation("scene1", false, false, false, true);

        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
