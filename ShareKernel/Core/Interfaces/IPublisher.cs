namespace ShareKernel.Core.Interfaces
{
    public interface IPublisher<T> where T : class
    {
        Task PublishAsync(T request, CancellationToken cancellationToken = default);

        Task PublishStringAsync(string message, CancellationToken cancellationToken = default);
    }
}
