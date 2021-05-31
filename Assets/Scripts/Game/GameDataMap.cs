public class GameDataMap : IGameData<Map>
{
    Map map;

    /// <returns>Returns false and value_out is null, if no map is created, otherwise returns true and map</returns>
    public bool Get(out Map value_out)
    {
        if (map == null)
        {
            value_out = null;
            return false;
        }
        else
        {
            value_out = map;
            return true;
        }
    }

    /// <summary>
    /// Rewrite map
    /// </summary>
    public void Set(Map newValue)
    {
        if (map == null)
        {
            map = newValue;
        }
        else
        {
            UnityEngine.MonoBehaviour.Destroy(map.Data.Map);
            map = newValue;
        }
    }
}