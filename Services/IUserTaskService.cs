using Punch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punch.Services
{
    public interface IUserTaskService
    {
        Task<List<UserTask>> GetAll();
        Task<UserTask> Delete(int id);
        Task<UserTask> Add(UserTask task);
        
    }
}
