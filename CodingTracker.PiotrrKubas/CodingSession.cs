﻿namespace CodingTracker.PiotrrKubas
{
    internal class CodingSession
    {
        public int Id { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
