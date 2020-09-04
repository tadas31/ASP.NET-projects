using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commander_api.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }

        public string Task { get; set; }

        public string CommandLine { get; set; }

        public string Platform { get; set; }
    }
}
