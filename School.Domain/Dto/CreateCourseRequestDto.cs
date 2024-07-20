namespace School.Domain.Dto
{
    public class CreateCourseRequestDto
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
    }
}
