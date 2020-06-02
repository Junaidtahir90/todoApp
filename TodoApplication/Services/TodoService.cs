using System;
using System.Collections.Generic;
using System.Linq;
using TodoApplication.Models;
using TodoApplication.Repository;


namespace TodoApplication.DataManager
{
    public class TodoService : ITodoRepository<Task,long>
    {
        TodoDBContext ctx;
        public TodoService(TodoDBContext c)
        {
            ctx = c;
        }

        public Task Get(long id)
        {
            var student = ctx.Tasks.FirstOrDefault(b => b.Id == id);
            return student;
        }

        public IEnumerable<Task> GetAll()
        {
            var tasks = ctx.Tasks.OrderByDescending(tsk=>tsk.Id).ToList();
            return tasks;
        }

        //public IEnumerable<Status> GetAllStauses()
        //{
        //    var statuses = ctx.Statuses.ToList();
        //    return statuses;
        //}
        public Task Add(Task task)
        {
           int  statusId = 1;
            long taskID = 0;
            if((task.StatusId<= 1))
            {
                task.StatusId = statusId;
            }
            else
            {
                task.StatusId = task.StatusId;
            }
            task.CreatedDate = DateTime.Now;
            task.UpdatedDate = DateTime.Now;
            ctx.Tasks.Add(task);
            
            ctx.SaveChanges();
            //ctx.SaveChanges();
            //(taskID) = task.Id;
            return task;
        }

        public long Delete(long id)
        {
            int taskID = 0;
            var task = ctx.Tasks.FirstOrDefault(b => b.Id == id);
            if (taskID != null)
            {
                ctx.Tasks.Remove(task);
                taskID = ctx.SaveChanges();
            }
            return taskID;
        }

        public Task Update(long id, Task task)
        {
            var taskDTO =  new Models.Task();
            var updateTask = ctx.Tasks.Find(id);
            if (updateTask != null)
            {
                updateTask.Title = task.Title;
                updateTask.Description = task.Description;
                updateTask.StatusId = task.StatusId;
                updateTask.UpdatedDate = DateTime.Now;
                ctx.SaveChanges();
                taskDTO = updateTask;
            }
            return taskDTO;
        }
    }
}
