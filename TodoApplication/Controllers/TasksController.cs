using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Models;
using TodoApplication.Repository;
using TodoApplication.DataManager;


namespace TodoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITodoRepository<Models.Task, long> _iRepo;
        TodoDBContext ctx;
        //public TodoService(TodoDBContext c)
        //{
        //    ctx = c;
        //}
        public TasksController(ITodoRepository<Models.Task,long> repo, TodoDBContext c)
        {
            _iRepo = repo;
            ctx = c;
        }

        // GET: api/Tasks  
        [HttpGet]
        public IEnumerable<Models.Task> Get()
        {
            try
            {
                var tasks = new List<Models.Task>();
                var response= _iRepo.GetAll();
                if(response!= null)
                {
                    return (response);
                }
                else
                {
                    return tasks;
                }
                //return 
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }

         
        [HttpGet("{id}")]
        public Models.Task Get(int id)
        {
            var task = new Models.Task();
            var response= _iRepo.Get(id);
            if(response!= null)
            {
                return response;
            }
            else
            {
                return task;
            }
           //
        }

        // POST api/tasks/CreateTask  
        [HttpPost]
        public IActionResult Post([FromBody] Models.Task taskDTO)
        {
            var task = new Models.Task();
            try
            {
                // var task = _iRepo.GetAll();
                if (taskDTO != null)
                {
                   var _response= _iRepo.Add(taskDTO);
                   // return response;
                    return Ok(new
                    {
                        response = _response
                    });
                    //var response= _iRepo.Add(taskDTO);
                    //return (response);
                }
                else
                {
                    return NotFound(new
                    {
                        response = task
                    });
                   // return task;
                    //return(0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

           // _iRepo.Add(student);
        }

        // POST api/tasks/UpdateTask  
        [HttpPut]
        //  public Models.Task Put([FromBody]Models.Task task)
        public IActionResult Put([FromBody]Models.Task task)
        {

            var taskDTO = new Models.Task();
            try
            {
                if (task != null)
                {
                   var _response = _iRepo.Update(task.Id, task);
                    return Ok(new
                    {
                        response = _response
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        response = taskDTO
                    });
                    //return taskDTO;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return (student.Id);
            // _iRepo.Update(studentStudentId, student);
        }

        // DELETE api/tasks/  
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }

        [HttpGet("FetchStatuses")]
        public IEnumerable<Status> GetAllStatuses()
        {
            try
            {
                var status = new List<Status>();
                //var stauses=
                var response = ctx.Statuses.ToList();
                if (response != null)
                {
                    return (response);
                }
                else
                {
                    return status;
                }
                //return 
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}