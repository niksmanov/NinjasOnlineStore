using System.Collections.Generic;
using NinjasOnlineStore.App.Core.Commands.Contracts;
using NinjasOnlineStore.Core.Providers;

namespace NinjasOnlineStore.Core.Commands
{
    public class GenerateReportCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            const string fileName = "NinjasOnlineStoreReport.pdf";

            PdfReportWriter.GeneratePdfReport(fileName);

            return "Report created successfully!";
        }
    }
}
