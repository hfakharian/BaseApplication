using NLog.LayoutRenderers;
using NLog;
using System.Diagnostics;
using System.Text;

namespace Api.Extensions
{
    [LayoutRenderer("assembly-versions")]
    public class AssemblyVersionsLayoutRenderer : StackTraceLayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var assm = typeof(Program).Assembly;
            var name = assm.GetName()?.Name ?? assm.FullName;
            var version = FileVersionInfo.GetVersionInfo(assm.Location).ProductVersion;
            builder.Append(string.Format("{0} - {1}", name, version));
        }
    }
}
