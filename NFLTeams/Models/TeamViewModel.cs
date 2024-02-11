namespace NFLTeams.Models
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public string ActiveConf { get; set; }
        public string ActiveDiv { get; set; }

        public string ActiveName { get; set; } = string.Empty;
    }
}
