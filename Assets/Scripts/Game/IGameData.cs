public interface IGameData<T>
{
    public bool Get(out T value_out);
    public void Set(T newValue);
}
