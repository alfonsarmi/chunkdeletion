using Serilog.Core;
using Serilog.Events;
using System.Collections.Generic;
using static Framework.Configuration.Constants;

namespace Alintia.Services.Agent.Serilog.Enrichers
{
    public class BatchQContextEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var batchQContextProperties = new List<string>(); ;
            if (logEvent.Properties.ContainsKey(SerilogProperties.Tenant))
            {
                var value = logEvent.Properties[SerilogProperties.Tenant].ToString().Replace("\"", "");
                if (!string.IsNullOrEmpty(value)) batchQContextProperties.Add($"t:{value}");
            }

            if (logEvent.Properties.ContainsKey(SerilogProperties.Batch) &&
                !string.IsNullOrEmpty(logEvent.Properties[SerilogProperties.Batch].ToString()))
            {
                var value = logEvent.Properties[SerilogProperties.Batch].ToString().Replace("\"", "");
                if (!string.IsNullOrEmpty(value)) batchQContextProperties.Add($"b:{value}");
            }

            if (logEvent.Properties.ContainsKey(SerilogProperties.Job))
            {
                var value = logEvent.Properties[SerilogProperties.Job].ToString().Replace("\"", "");
                if (!string.IsNullOrEmpty(value)) batchQContextProperties.Add($"j:{value}");
            }

            if (logEvent.Properties.ContainsKey(SerilogProperties.JobDef))
            {
                var value = logEvent.Properties[SerilogProperties.JobDef].ToString().Replace("\"", "");
                if (!string.IsNullOrEmpty(value)) batchQContextProperties.Add($"jd:{value}");
            }

            if (logEvent.Properties.ContainsKey(SerilogProperties.ApplicationSourceId))
            {
                var value = logEvent.Properties[SerilogProperties.ApplicationSourceId].ToString().Replace("\"", "");
                if (!string.IsNullOrEmpty(value)) batchQContextProperties.Add($"app:{value}");
            }

            if (logEvent.Properties.ContainsKey(SerilogProperties.ResourceId))
            {
                var value = logEvent.Properties[SerilogProperties.ResourceId].ToString().Replace("\"", "");
                if (!string.IsNullOrEmpty(value)) batchQContextProperties.Add($"rid:{value}");
            }

            var str = string.Join(" ", batchQContextProperties);
            var logEventProperty = propertyFactory.CreateProperty(SerilogProperties.BatchQContext, str);
            logEvent.AddPropertyIfAbsent(logEventProperty);

        }
    }
}
