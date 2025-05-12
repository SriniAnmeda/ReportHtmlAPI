using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HtmlStorageApi.Models
{
    public class HtmlReport
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ReportId")]
        public string ReportId { get; set; }

        [BsonElement("HtmlContent")]
        public string? HtmlContent { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
    }
}
