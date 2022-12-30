using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDo.DAL.Interfaces;

namespace ToDo.BLL.Modules
{
    public class TasksRemover : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TasksRemover(IServiceScopeFactory serviceScopeFactory) 
        {
            _serviceScopeFactory = serviceScopeFactory;  
        }

        private async Task DeleteOldTasks()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IUserTaskRepository>();
            await service.DeleteCompleted();
            scope.Dispose();
        }

        private async void DoWork(object state)
        {
            await DeleteOldTasks();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(6));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
