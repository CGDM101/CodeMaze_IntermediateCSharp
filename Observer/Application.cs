namespace Observer
{
    public class Application
    {
        public int JobId { get; set; }
        public string ApplicantName { get; set; }

        public Application(int jobiId, string applicantName)
        {
            JobId = jobiId;
            ApplicantName = applicantName;
        }
    }
}
