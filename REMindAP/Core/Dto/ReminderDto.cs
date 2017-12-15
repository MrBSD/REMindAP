using REMindAP.Core.Domain;

namespace REMindAP.Core.Dto
{
    public class ReminderDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int ReminderTypeId { get; set; }
        public bool IsCanceled { get; private set; }
        public bool IsRepeatable { get; set; }

    }
}