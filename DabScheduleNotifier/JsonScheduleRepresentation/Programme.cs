namespace DabScheduleNotifier.JsonScheduleRepresentation
{
    public class Programme
    {
        public string type { get; set; }
        public string pid { get; set; }
        public int? position { get; set; }
        public string title { get; set; }
        public string short_synopsis { get; set; }
        public string media_type { get; set; }
        public int duration { get; set; }
        public DisplayTitles display_titles { get; set; }
        public string first_broadcast_date { get; set; }
        public Ownership ownership { get; set; }
        public Programme programme { get; set; }
        public string available_until { get; set; }
        public string actual_start { get; set; }
        public bool is_available_mediaset_pc_sd { get; set; }
        public bool is_legacy_media { get; set; }
        public Media media { get; set; }
        public object expected_child_count { get; set; }
    }
}