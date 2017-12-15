using System.Collections.Generic;

namespace REMindAP.Core.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public ICollection<ReminderTag> ReminderTags { get; set; }

        public Tag()
        {
            ReminderTags = new List<ReminderTag>();
        }
    }
}
