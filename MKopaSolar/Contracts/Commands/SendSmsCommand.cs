namespace MKopaSolar.Contracts.Commands
{
    public class SendSmsCommand
    {
        public string PhoneNumber { get; set; }
        public string SmsText { get; set; }
    }
}
