using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public DateTime deadline { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public CategoryLkp CategoryLkp { get; set; }
        public StatusLkp StatusLkp { get; set; }
        [ForeignKey("CategoryLKP")]
        public int category_lkp_id { get; set; }
        [ForeignKey("StatusLKP")]
        public int status_lkp_id { get; set; }
    }
}