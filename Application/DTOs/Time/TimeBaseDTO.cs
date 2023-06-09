﻿namespace Application.DTOs.Time;

public class TimeBaseDTO
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid ArenaId { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public string CustomerFullName { get; set; }
}
