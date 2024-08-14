namespace ShareKernel.Core.Interfaces
{
    public interface IStateStore<T> where T : class
    {
        Task<T?> GetAsync(int id, CancellationToken cancellationToken = default);

        Task UpsertAsync(T state, CancellationToken cancellationToken = default);
    }
}
