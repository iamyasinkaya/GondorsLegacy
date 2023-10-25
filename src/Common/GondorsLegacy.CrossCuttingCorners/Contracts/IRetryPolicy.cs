namespace GondorsLegacy.CrossCuttingCorners.Contracts;

    public interface IRetryPolicy<T>
    {
        T Execute(Func<T> action);

        Task<T> ExecuteAsync(Func<Task<T>> asyncAction);

        T Execute(Func<T> action, int retryCount);
        Task<T> ExecuteAsync(Func<Task<T>> asyncAction, int retryCount);

        T Execute(Func<T> action, int retryCount, TimeSpan retryInterval);
        Task<T> ExecuteAsync(Func<Task<T>> asyncAction, int retryCount, TimeSpan retryInterval);

        T Execute(Func<T> action, Func<Exception, bool> exceptionPredicate);
        Task<T> ExecuteAsync(Func<Task<T>> asyncAction, Func<Exception, bool> exceptionPredicate);
    }

