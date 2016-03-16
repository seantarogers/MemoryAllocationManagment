namespace LargeObjectPooling
{
    public class Customer
    {
        private string Name { get; set; }
        private string MobileNumberNumber { get; set; }

        private byte[] TermsAndConditionsPdf { get; set; }

        public Customer(int byteSize, string name, string mobileNumber)
        {
            TermsAndConditionsPdf = new byte[byteSize];
            Name = name;
            MobileNumberNumber = mobileNumber;

        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            MobileNumberNumber = phoneNumber;
        }
    }
}