namespace School.Domain.Dto
{
    public class UdpdateCourseRequestDto
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
    }
}
