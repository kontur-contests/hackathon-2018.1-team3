using System;

public class LevelMap 
{
    MyLocation[,] locations;
    private int gridSize = 25;

    public LevelMap(string composition)
    {
        if (composition == "comp1")
        {
            locations = new MyLocation[gridSize, gridSize];
            //pretty random level 1;
            locations[0, 0] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);
            locations[1, 0] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);
            locations[2, 0] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);
            locations[2, 1] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);
            locations[3, 1] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);
            locations[4, 1] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);
            locations[3, 0] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);
            locations[3, 2] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);//reward room?
            locations[3, 3] = new MyLocation("Pool1-Monster-4way", up: false, down: false, left: false, right: true);
            locations[5, 1] = new MyLocation("sceneBoss1", up: false, down: false, left: false, right: true);
            locations[6, 1] = new MyLocation("sceneShop1", up: false, down: false, left: false, right: true);
        }
    }

    public string GetRoomNameByCoords(int i, int j)
    {
        try
        {
            if (locations[i, j] != null)
            {
                return locations[i, j].sceneName;
            }
            else
            {
                return "";
            }
        }
        catch (IndexOutOfRangeException)
        {
            return "";
        }
    }
}
