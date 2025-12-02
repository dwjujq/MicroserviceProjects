
using System;
using System.Threading.Tasks;
using Order.IServices.BASE;
using Order.Model;
using Order.Model.Models;

namespace Order.IServices
{	
	/// <summary>
	/// ITasksLogServices
	/// </summary>	
    public interface ITasksLogServices :IBaseServices<TasksLog>
	{
		public Task<PageModel<TasksLog>> GetTaskLogs(long jobId, int page, int intPageSize,DateTime? runTime,DateTime? endTime);
        public Task<object> GetTaskOverview(long jobId, DateTime? runTime, DateTime? endTime, string type);
    }
}
                    