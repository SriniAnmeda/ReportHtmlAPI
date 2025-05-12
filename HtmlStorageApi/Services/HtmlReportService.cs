using HtmlStorageApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HtmlStorageApi.Services
{
    public class HtmlReportService
    {
        private readonly IMongoCollection<HtmlReport> _htmlReports;

        public HtmlReportService(MongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _htmlReports = database.GetCollection<HtmlReport>(settings.CollectionName);
        }

        // Add new report
        public async Task CreateAsync(HtmlReport report) =>
            await _htmlReports.InsertOneAsync(report);

        // Get report by ReportId
        public async Task<HtmlReport> GetByReportIdAsync(string reportId) =>
            await _htmlReports.Find(r => r.ReportId == reportId).FirstOrDefaultAsync();

        // Check if report exists
        public async Task<bool> ReportExistsAsync(string reportId) =>
            await _htmlReports.Find(r => r.ReportId == reportId).AnyAsync();
    }
}
