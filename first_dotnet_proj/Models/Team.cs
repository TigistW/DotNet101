using System.ComponentModel.DataAnnotations.Schema;

namespace first_dotnet_proj.Models;

    public class Team
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Country { get; set; }
        public string TeamPrinciple { get; set; }

    }