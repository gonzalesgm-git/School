namespace School.Domain.Dto
{
    public class CreateApplicationDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
