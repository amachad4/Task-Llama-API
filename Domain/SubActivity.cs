using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class SubActivity
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime deadline { get; set; }
        public Activity Activity { get; set; }
        public StatusLkp StatusLkp { get; set; }
        [ForeignKey("Activity")]
        public Guid activity_id { get; set; }
        [ForeignKey("StatusLKP")]
        public int status_lkp_id { get; set; }
    }
}