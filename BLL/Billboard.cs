namespace BLL
{
    public class Billboard
    {
        public string Category { get; set; }
        public string Tags { get; set; }
        public string User { get; set; }
        public bool IsActive { get; set; } = true;
    }
}