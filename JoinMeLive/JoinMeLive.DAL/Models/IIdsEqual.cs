namespace JoinMeLive.DAL.Models
{
    public interface IIdsEqual<in T> where T : IIdsEqual<T>
    {
        bool IdsEqual(T other);
    }
}
