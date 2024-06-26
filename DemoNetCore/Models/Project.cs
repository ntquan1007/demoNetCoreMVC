namespace DemoNetCore.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string CodeProject { get; set; }
        public string NameProject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate {  get; set; }
        public StatusProject StatusProject { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
