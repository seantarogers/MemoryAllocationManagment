namespace LargeObjectPooling
{
    using System;
    using System.Runtime;

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

            var myReferenceType = new MyReferenceType();


            GCSettings.LatencyMode = GCLatencyMode.LowLatency;


            GC.Collect(2);

            GCSettings.LargeObjectHeapCompactionMode 
                = GCLargeObjectHeapCompactionMode.CompactOnce;



            GC.SuppressFinalize(this);

            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;

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

    public class MyReferenceType
    {
    }
}