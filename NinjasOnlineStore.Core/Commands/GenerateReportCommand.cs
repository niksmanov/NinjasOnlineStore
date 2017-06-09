using System.Collections.Generic;
using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.Core.Contracts;

namespace NinjasOnlineStore.Core.Commands
{
    public class GenerateReportCommand : ICommand
    {
        private readonly IPdfReportWriter reportWriter;
        public GenerateReportCommand(IPdfReportWriter reportWriter)
        {
            this.reportWriter = reportWriter;
        }
        public string Execute(IList<string> parameters)
        {
            const string fileName = "NinjasOnlineStoreReport.pdf";

            this.reportWriter.GeneratePdfReport(fileName);

            return "Report created successfully!";
        }
    }
}
