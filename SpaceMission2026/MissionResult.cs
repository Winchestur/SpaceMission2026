using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMission2026
{
    public class MissionResult
    {
        public string? AstronautName { get; set; }

        public int Steps { get; set; }

        public string[,]? Map { get; set; }
    }
}
