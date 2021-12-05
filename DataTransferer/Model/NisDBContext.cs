using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataTransferer.Model
{
    public class NisDBContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<AgTestsByRegion> AgTestsByRegions { get; set; }
        public DbSet<HospitalbbedsByRegion> HOspitalbbedsByRegions { get; set; }
        public DbSet<HospitalPatientsByRegion> HospitalPatientsByRegions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var user = "ADMIN";
            var pswd = "Nisdbfriunizask1.";
            var ds = "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=adb.eu-frankfurt-1.oraclecloud.com))(connect_data=(service_name=g6befa2bcc92a28_nisdb_high.adb.oraclecloud.com))(security=(ssl_server_cert_dn=\"CN = adwc.eucom - central - 1.oraclecloud.com, OU = Oracle BMCS FRANKFURT, O = Oracle Corporation, L = Redwood City, ST = California, C = US\")))";

            options.UseOracle($"User Id={user};Password={pswd};Data Source={ds};");
        }

        [Table("REGION")]
        public class Region
        {
            [Key, JsonProperty("id")]
            public int ID { get; set; }

            [JsonProperty("title")]
            public string TITLE { get; set; }
            [JsonProperty("code")]
            public string CODE { get; set; }
            [JsonProperty("abbreviation")]
            public string ABBREVIATION { get; set; }
        }

        [Table("AGTESTSBYREGION")]
        public class AgTestsByRegion
        {
            [Key, JsonProperty("id")] // id
            public int RECORD_ID { get; set; }

            [JsonProperty("positivity_rate")]
            public double POSITIVITY_ID { get; set; }

            [ForeignKey("REGION")]
            public int REGION_ID { get; set; }
            //public Region REGION { get; set; }

            [JsonProperty("published_on")]
            public DateTime PUBLISHED_ON { get; set; }

            public int POSITIVES_COUNT { get; set; }
            public int NEGATIVES_COUNT { get; set; }

            public int POSITIVES_SUM { get; set; }
            public int NEGATIVE_SUM { get; set; }
        }

        [Table("HOSPITALBBEDSBYREGION")]
        public class HospitalbbedsByRegion
        {
            [Key, JsonProperty("id")]
            public int RECORD_ID { get; set; }

            [JsonProperty("published_on")]
            public DateTime PUBLISHED_ON { get; set; }

            [ForeignKey("REGION"), JsonProperty("region_id")]
            public int REGION_ID { get; set; }
            //public Region REGION { get; set; }

            public int CAPACITY_COVID { get; set; }
            public int OCCUPIED_JIS_COVID { get; set; }
            public int OCCUPIED_OAIM_COVID { get; set; }
            public int OCCUPIED_O2_COVID { get; set; }
            public int OCCUPIED_OTHER_COVID { get; set; }
        }

        [Table("HOSPITALPATIENTSBYREGION")]
        public class HospitalPatientsByRegion
        {
            [Key, JsonProperty("id")]
            public int RECORD_ID { get; set; }

            [JsonProperty("published_on")]
            public DateTime PUBLISHED_ON { get; set; }

            [ForeignKey("REGION")]
            public int REGION_ID { get; set; }
            //public Region REGION { get; set; }

            public int CONFIRMED_COVID { get; set; }
            public int VENTILATED_COVID { get; set; }
        }
    }
}
