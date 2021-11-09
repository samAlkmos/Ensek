
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Ensek.Entity.Entities
{
    public class MeterReadingModel
    {
        [Key]
        [Ignore]
        public Guid Id { get; set; }
        public int AccountId { get; set; }

        public string MeterReadingDateTime { get; set;}
        public string MeterReadValue { get; set; }
    }

 

    public class ModelClassMap : ClassMap<MeterReadingModel>
    {
        public ModelClassMap()
        {
            Map(m => m.AccountId).Name("AccountId");
            Map(m =>m.MeterReadingDateTime).Name("MeterReadingDateTime");
            Map(m => m.MeterReadValue).Name("MeterReadValue");
        }
    }
}
