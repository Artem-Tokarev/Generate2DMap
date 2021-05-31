using UnityEngine;

public class MapData
{
    public GameObject Map { get; private set; }
    public string LinkToMapJson { get; private set; } = "/JSON/Map/mapOne.json";
    public string PathToSprites { get; private set; } = "Map/One/";
    public float Width { get; private set; }
    public float Height { get; private set; }

    public MapData()
    {
        LinkToMapJson = Application.dataPath + LinkToMapJson;
    }

    public void SetMap(GameObject map)
    {
        Map = map;
    }

    public void SetLinkToMapJson(string linkToMapJson)
    {
        LinkToMapJson = linkToMapJson;
    }

    public void SetPathToSprites(string pathToSprites)
    {
        PathToSprites = pathToSprites;
    }

    public void SetWidth(float width)
    {
        Width = width;
    }

    public void SetHeight(float height)
    {
        Height = height;
    }
}
