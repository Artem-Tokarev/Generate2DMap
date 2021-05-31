public class GameDataCameraPan : IGameData<CameraPan>
{
    CameraPan cameraPan;

    /// <returns>Returns false and value_out is null, if no map is created, otherwise returns true and CameraPan</returns>
    public bool Get(out CameraPan value_out)
    {
        if (cameraPan == null)
        {
            value_out = null;
            return false;
        }
        else
        {
            value_out = cameraPan;
            return true;
        }
    }

    /// <summary>
    /// Rewrite CameraPan
    /// </summary>
    public void Set(CameraPan newValue)
    {
        if (cameraPan == null)
        {
            cameraPan = newValue;
        }
        else
        {
            UnityEngine.MonoBehaviour.Destroy(cameraPan.gameObject);
            cameraPan = newValue;
        }
    }
}
