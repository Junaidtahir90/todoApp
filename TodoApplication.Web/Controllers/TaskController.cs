using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Web.Helper;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

namespace TodoApplication.Web.Controllers
{
    public class TaskController : Controller
    {
        private string apiEndpoint = "api/tasks/";

        TodoAPI _todoAPI = new TodoAPI();
       
        // GET: Tasks/Index  
        public async Task<IActionResult> Index()
        {
            List<TaskDTO> dto = new List<TaskDTO>();
            //var allStatuses = await FetchStatuses();
            //if(allStatuses != null)
            //{
            //   // allStatuses;
            //}
            //else
            //{
            //    //statuses=
            //}
            HttpClient client = _todoAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync(apiEndpoint);

            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<TaskDTO>>(result);
            }
            //returning the employee list to view    
            return View(dto);
        }
        //public async Task<IActionResult> FetchStatuses()
        //{
        //    List<StatusDTO> dto = new List<StatusDTO>();

        //    HttpClient client = _todoAPI.InitializeClient();

        //    HttpResponseMessage res = await client.GetAsync(apiEndpoint + "/FetchStatuses");

        //    //Checking the response is successful or not which is sent using HttpClient    
        //    if (res.IsSuccessStatusCode)
        //    {
        //        //Storing the response details recieved from web api     
        //        var result = res.Content.ReadAsStringAsync().Result;

        //        //Deserializing the response recieved from web api and storing into the Employee list    
        //        dto = JsonConvert.DeserializeObject<List<StatusDTO>>(result);

        //    }
        //    //returning the employee list to view    
        //    return View(dto);
        //}

        // GET: Tasks/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Description,StatusId")] TaskDTO taskDTO)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _todoAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(taskDTO), Encoding.UTF8,"application/json");
                HttpResponseMessage res = client.PostAsync(apiEndpoint, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(taskDTO);
        }

        // GET: Tasks/Edit/  
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<TaskDTO> dto = new List<TaskDTO>();
            HttpClient client = _todoAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync(apiEndpoint);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<TaskDTO>>(result);
            }

            var task = dto.SingleOrDefault(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Edit/  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Title,Description,StatusId")] TaskDTO taskDTO)
        {
            if (id != taskDTO .Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _todoAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(taskDTO), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync(apiEndpoint, content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(taskDTO);
        }

        // GET: Tasks/Delete/  
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<TaskDTO> dto = new List<TaskDTO>();
            HttpClient client = _todoAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync(apiEndpoint);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<TaskDTO>>(result);
            }

            var task = dto.SingleOrDefault(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/  
        [HttpPost ,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            HttpClient client = _todoAPI.InitializeClient();
          //  HttpResponseMessage res = client.DeleteAsync($"'" + apiEndpoint + "'/{id}").Result;
           // HttpResponseMessage res = client.DeleteAsync($"'" + apiEndpoint + "'"+"/",{id}).Result;
            HttpResponseMessage res = client.DeleteAsync($"api/tasks/{id}").Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}
