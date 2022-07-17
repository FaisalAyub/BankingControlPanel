namespace MCN.ServiceRep.BAL.ViewModels.Login
{
    public class EmailVerificationEmailDTO
    {
        public string Passcode { get; set; }
        public string Email { get; set; }
        public string BaseURI { get; set; }
        public string FormName { get; set; }
        public int FormId { get; set; }
        public string FormSupportEmail { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FormURL { get; set; }
    }
}
