using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace AplikacjaARPIdeas.Models
{
    public class WorkerRepository : IWorkerRepository
    {
        private IHostingEnvironment _hostingEnvironment;

        
        private List<Worker> allWorkers;
        private XDocument workerData;
        

        public WorkerRepository(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "WorkerList.xml");
            allWorkers = new List<Worker>();
            workerData = XDocument.Load(path);
            var workers = from workerlist in workerData.Descendants("worker")
                          select new Worker((int)workerlist.Element("id"),
                                                 workerlist.Element("name").Value,
                                                 workerlist.Element("surname").Value,
                                            (int)workerlist.Element("age"),
                                        (decimal)workerlist.Element("salary"),
                                          (float)workerlist.Element("identyficationnumber"));

            allWorkers.AddRange(workers.ToList<Worker>());
        }


        public IEnumerable<Worker> GetAllWorkers()
        {
            //var path = Path.Combine(_hostingEnvironment.WebRootPath, "WorkerList.xml");
            //allWorkers = new List<Worker>();
            //workerData = XDocument.Load(path);
            return allWorkers;
        }

        public Worker GetWorkersById(int id)
        {
            return allWorkers.Find(item => item.Id == id);
        }

        public void AddWorker(Worker worker)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorker(int id)
        {
            throw new NotImplementedException();
        }

        public void EditWorker(Worker worker)
        {
            throw new NotImplementedException();
        }
    }
}
