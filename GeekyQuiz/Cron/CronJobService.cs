using Cronos;
using System.ComponentModel;

namespace GeekyQuiz.Cron
{
    public class CronJobService : IHostedService, IDisposable
    {
        private System.Timers.Timer _timer;
        private readonly CronExpression _cronExpression;
        private readonly TimeZoneInfo _timeZone;

        protected CronJobService(string cronExpression, TimeZoneInfo timeZone)
        {
            _cronExpression = CronExpression.Parse(cronExpression);
            _timeZone = timeZone;
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            await ScheduleJob(cancellationToken);
        }
        public virtual async Task ScheduleJob(CancellationToken cancellationToken)
        {
            var next = _cronExpression.GetNextOccurrence(DateTimeOffset.Now, _timeZone);
            if (next.HasValue)
            {
                var delay = next.Value - DateTimeOffset.Now;
                if (delay.TotalMilliseconds <= 0)
                {
                    await ScheduleJob(cancellationToken);
                }
                _timer = new System.Timers.Timer(delay.TotalMilliseconds);
                _timer.Elapsed += async (sender, args) =>
                {
                    _timer.Dispose();
                    _timer = null;
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await DoWork(cancellationToken);
                    }
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        await ScheduleJob(cancellationToken);
                    }
                };
                _timer.Start();
            }
            await Task.CompletedTask;
        }
        public virtual async Task DoWork(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
        }
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Stop();
            await Task.CompletedTask;
        }
        public virtual void Dispose()
        {
            _timer?.Dispose();
        }
    }
}