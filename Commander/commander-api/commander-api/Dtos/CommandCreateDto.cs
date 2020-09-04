using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace commander_api.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        public string Task { get; set; }

        [Required]
        public string CommandLine { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
