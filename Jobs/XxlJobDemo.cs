using DotXxlJob.Core;
using DotXxlJob.Core.Model;

namespace CherryWeb.Jobs;

[JobHandler("demoJobHandler")]
public class XxlJobDemo : AbstractJobHandler
{
    public override Task<ReturnT> Execute(JobExecuteContext context)
    {
        context.JobLogger.Log("执行job, parameter: {0}", context.JobParameter);
        return Task.FromResult(ReturnT.SUCCESS);
    }
}