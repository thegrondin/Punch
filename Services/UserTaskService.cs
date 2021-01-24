using Punch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punch.Services
{
    public class UserTaskService : IUserTaskService
    {
        public Task<UserTask> Add(UserTask task)
        {
            throw new NotImplementedException();
        }

        public Task<UserTask> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserTask>> GetAll()
        {
            UserTask task = new UserTask { Description = "test" };
            return new List<UserTask> {
                new UserTask{ Description = "Ceci est une description", Duration = new TimeSpan(), Name = "Task No. 1", End = TimeSpan.Zero, Start = TimeSpan.Zero},
                new UserTask{ Description = "Ceci est une description", Duration = new TimeSpan(), Name = "Task No. 2", End = TimeSpan.Zero, Start = TimeSpan.Zero},
            };
        }
    }
}
