using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePause : MonoBehaviour
{
    public Text nameNearSpriteMap;

    public void Pause()
    {
        Time.timeScale = 0;
        GameData.CameraPan.Get(out CameraPan cameraPan);
        cameraPan.Data.IsPan = false;
    }

    public void Continue()
    {
        Time.timeScale = 1;
        GameData.CameraPan.Get(out CameraPan cameraPan);
        cameraPan.Data.IsPan = true;
    }

    public void GetNameNearSpriteMap()
    {
        GameData.Map.Get(out Map map);
        List<Transform> partsMap = new List<Transform>();
        partsMap.AddRange(map.Data.Map.GetComponentsInChildren<Transform>());
        partsMap.RemoveAt(0);//it is parent transform (map transform)
        Vector3 pointStartFindNearSprite = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        float distanceSmallest = Vector3.Distance(pointStartFindNearSprite, partsMap[0].transform.position);
        int index = 0;
        for (int i = 1; i < partsMap.Count; i++)
        {
            float nextDistance = Vector3.Distance(pointStartFindNearSprite, partsMap[i].transform.position);
            if (nextDistance < distanceSmallest)
            {
                distanceSmallest = nextDistance;
                index = i;
            }
        }
        nameNearSpriteMap.text = partsMap[index].GetComponent<SpriteRenderer>().sprite.name;
    }
}
