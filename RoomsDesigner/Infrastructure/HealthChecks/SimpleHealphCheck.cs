using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace RoomsDesigner.Api.Infrastructure.HealthChecks
{
    public class SimpleHealphCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new HealthCheckResult(HealthStatus.Healthy));
        }
    }
}
