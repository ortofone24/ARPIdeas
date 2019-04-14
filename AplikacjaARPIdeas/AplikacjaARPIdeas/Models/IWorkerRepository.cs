using System.Collections.Generic;

namespace AplikacjaARPIdeas.Models
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorkersById(int id);

        void AddWorker(Worker worker);
        void DeleteWorker(int id);
        void EditWorker(Worker worker);
    }
}
