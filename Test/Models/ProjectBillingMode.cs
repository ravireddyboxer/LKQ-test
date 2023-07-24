namespace Test.Models
{
    public class ProjectBillingMode
    {
        public int Id { get; set; }
        public string Name { get; set; }  // Hourly or by Mile stones

        public int TotalHoursCompleted { get;set; }
        public int TotalMileStonesCompleted { get; set; }
    }
}
