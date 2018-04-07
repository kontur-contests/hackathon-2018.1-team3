using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelMap : MonoBehaviour {
    MyLocation[,] locations;
    public LevelMap(string composition)
    {
        if (composition == "comp1")
        {
            int gridSize = 25;
            locations = new MyLocation[gridSize, gridSize];
            //pretty random level 1;
            locations[0, 0] = new MyLocation("scene0", up:false, down:false, left:false, right:true);
            locations[1, 0] = new MyLocation("scene1", up: false, down: false, left: false, right: true);
            locations[2, 0] = new MyLocation("scene2", up: false, down: false, left: false, right: true);
            locations[2, 1] = new MyLocation("scene3", up: false, down: false, left: false, right: true);
            locations[3, 1] = new MyLocation("scene4", up: false, down: false, left: false, right: true);
            locations[4, 1] = new MyLocation("scene5", up: false, down: false, left: false, right: true);
            locations[3, 0] = new MyLocation("scene6", up: false, down: false, left: false, right: true);
            locations[3, 2] = new MyLocation("scene7", up: false, down: false, left: false, right: true);//reward room?
            locations[3, 3] = new MyLocation("scene8", up: false, down: false, left: false, right: true);
            locations[5, 1] = new MyLocation("sceneBoss1", up: false, down: false, left: false, right: true);
            locations[6, 1] = new MyLocation("sceneShop1", up: false, down: false, left: false, right: true);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
