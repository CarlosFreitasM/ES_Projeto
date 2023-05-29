namespace Projeto_ESFase2.Data
{
    public interface ICompetitionObservable
    {
        void RegisterObserver(ICompetitionObserver observer);
        void UnregisterObserver(ICompetitionObserver observer);
        void NotifyObservers(string message);
    }

    
}
