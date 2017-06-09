namespace NinjasOnlineStore.Core.Contracts
{
    public interface IPdfReportWriter
    {
        void GeneratePdfReport(string fileName);
    }
}
