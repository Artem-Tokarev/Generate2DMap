using System.IO;
using UnityEngine;

public class Map
{
    public MapData Data { get; private set; } = new MapData();

    public Map()
    {
        GameData.Map.Set(this);
        Generate();
    }

    public Map(MapData mapData)
    {
        Data = mapData;
        GameData.Map.Set(this);
        Generate();
    }

    void Generate()
    {
        GameObject map = new GameObject("Map");
        Data.SetMap(map);
        string mapJson = File.ReadAllText(Data.LinkToMapJson);
        PartMapCollection partMapCollection = JsonUtility.FromJson<PartMapCollection>(mapJson);
        float mapWidth = 0, mapHeight = 0;
        foreach (PartMap partMap in partMapCollection.List)
        {
            if (partMap.Y == 0)
                mapWidth += partMap.Width;
            if (partMap.X == 0)
                mapHeight += partMap.Height;
            float x = (partMap.Width == partMap.Height) ? partMap.X : partMap.X - ((partMap.Height - partMap.Width) / 2);
            GameObject tileMap = new GameObject("tileMap_" + partMap.Id, typeof(SpriteRenderer));
            tileMap.transform.position = new Vector3(x, partMap.Y, 0);
            tileMap.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(Data.PathToSprites + partMap.Id);
            tileMap.transform.parent = map.transform;
        }
        Data.SetWidth(mapWidth);
        Data.SetHeight(mapHeight);
        AlignMap(partMapCollection.List[0], ref map);
    }

    /// <summary>
    /// Map alignment to start visual map position in Vector3 (0,0,0)
    /// </summary>
    void AlignMap(PartMap partMapOne, ref GameObject map)
    {
        Vector3 alignMapPosition = new Vector3(partMapOne.Width / 2, (partMapOne.Height / 2) * -1, 0);
        map.transform.position = alignMapPosition;
    }
}
