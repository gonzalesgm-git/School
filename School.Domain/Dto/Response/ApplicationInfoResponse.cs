﻿namespace School.Domain.Dto.Response
{
    public class ApplicationInfoResponse
    {
        public DateTime ApplicationDate { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
    }
}
