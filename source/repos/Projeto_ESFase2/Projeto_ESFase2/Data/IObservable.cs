namespace Projeto_ESFase2.Data
{
    public interface IObserver
    {
        void Update(IObservable observable);
        void UpdateUsers(int observable);
    }

    public interface IObservable
    {
        void AttachObserver(IObserver observer);
        void DetachObserver(IObserver observer);
        void NotifyObserver();
        void AttachUser(int userId);

    }

    public interface IObserverance
    {
        void AttachUser(int userId, int competitionId);
    }

    
}
