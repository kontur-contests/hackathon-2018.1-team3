using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLocation  {

    public string sceneName;
    public bool[] hasRooms;// up down left right

    public MyLocation(string name, bool up, bool down, bool left, bool right)
    {
        sceneName = name;
        hasRooms = new bool[4];
        hasRooms[0] =up;
        hasRooms[1] =down;
        hasRooms[2] =left;
        hasRooms[3] =right;
    }


	// Use this for initialization
}
