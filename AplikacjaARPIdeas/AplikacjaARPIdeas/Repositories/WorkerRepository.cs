﻿using AplikacjaARPIdeas.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AplikacjaARPIdeas.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private IHostingEnvironment _hostingEnvironment;
        
        private List<Worker> allWorkers;
        private XDocument workerData;
        

        public WorkerRepository()
        {
            
        }

        public WorkerRepository(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            var path = Path.Combine(_hostingEnvironment.WebRootPath, @"xml\WorkerList.xml");

            workerData = XDocument.Load(path);

            allWorkers = new List<Worker>();

            var workers =
            (
                from workerlist in workerData.Descendants("worker")
                select new Worker
                {
                    Id = (int)workerlist.Element("id"),
                    Name = (string)workerlist.Element("name"),
                    SureName = (string)workerlist.Element("surename"),
                    Age = (int)workerlist.Element("age"),
                    Salary = (decimal)workerlist.Element("salary"),
                    IdentyficationNumber = (int)workerlist.Element("identyficationnumber")
                }
            );

            allWorkers.AddRange(workers.ToList<Worker>());
        }

        
        public IEnumerable<Worker> GetAllWorkers()
        {
            return allWorkers;
        }

        public Worker GetWorkersById(int id)
        {
            return allWorkers.Find(item => item.Id == id);
        }

        public void AddWorker(Worker worker)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, @"xml\WorkerList.xml");
            worker.Id = (int)(from workerlist in workerData.Descendants("worker")
                              orderby (int)workerlist.Element("id")
                                  descending
                              select (int)workerlist.Element("id")).FirstOrDefault() + 1;

            workerData.Root.Add(new XElement("worker", new XElement("id", (int)worker.Id),
                                                       new XElement("name", (string)worker.Name),
                                                       new XElement("surename", (string)worker.SureName),
                                                       new XElement("age", (int)worker.Age),
                                                       new XElement("salary", (decimal)worker.Salary),
                                                       new XElement("identyficationnumber", (int)worker.IdentyficationNumber)
                                                       ));
            workerData.Save(path);
        }

        public void DeleteWorker(int id)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, @"xml\WorkerList.xml");
            workerData.Root.Elements("worker").Where(i => (int)i.Element("id") == id).Remove();
            workerData.Save(path);
        }

        public void EditWorker(Worker worker)
        {
            var path = Path.Combine(_hostingEnvironment.WebRootPath, @"xml\WorkerList.xml");
            XElement node = workerData.Root.Elements("worker")
                .FirstOrDefault(i => (int)i.Element("id") == worker.Id);

            node.SetElementValue("name", (string)worker.Name);
            node.SetElementValue("surename", (string)worker.SureName);
            node.SetElementValue("age", (int)worker.Age);
            node.SetElementValue("salary", (decimal)worker.Salary);
            node.SetElementValue("identyficationnumber", (int)worker.IdentyficationNumber);

            workerData.Save(path);
        }


    }
}
