namespace DemoNetCore.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public string Description { get; set; }
        public RoleProject RoleProject { get; set; }
    }
}
