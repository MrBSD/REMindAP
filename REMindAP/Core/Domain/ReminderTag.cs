namespace REMindAP.Core.Domain
{
    public class ReminderTag
    {
        public int ReminderId { get; set; }
        public Reminder Reminder { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
