using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.ViewModels.Home;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        private IEnumerable<Person> ReadJsonDb()
        {
            var path = Path.Combine(_env.ContentRootPath, "Data", "json.txt");
            using (var reader = new StreamReader(path))
            {
                return JsonConvert.DeserializeObject<List<Person>>(reader.ReadToEnd());
            }
        }

        private IEnumerable<Person> ReadJsonDb(int numOfRecords)
        {
            var retval = ReadJsonDb();
            return numOfRecords > 0 ? retval.Take(numOfRecords) : retval;
        }

        // GET: /Home/
        public ActionResult Index(int page = 1, string sort = "FirstName", string sortDir = "ASC")
        {
            var persons = ReadJsonDb();
            switch (sort)
            {
                case "FirstName":
                    persons = sortDir == "ASC" ? persons.OrderBy(p => p.FirstName) : persons.OrderByDescending(p => p.FirstName);
                    break;
                case "LastName":
                    persons = sortDir == "ASC" ? persons.OrderBy(p => p.LastName) : persons.OrderByDescending(p => p.LastName);
                    break;
            }
            var totalCount = persons.Count();
            var pageSize = 10;
            persons = persons.Skip((page - 1) * pageSize).Take(pageSize);
            var model = new HomeIndexViewModel()
            {
                Data = persons,
                PageIndex = page,
                TotalCount = totalCount
            };
            return View(model);
        }
    }
}
