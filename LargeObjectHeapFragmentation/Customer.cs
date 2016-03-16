namespace LargeObjectHeapFragmentation
{
    public class Customer
    {
        private byte[] TermsAndConditionsPdf { get; set; }

        public Customer(int byteSize)
        {
            TermsAndConditionsPdf = new byte[byteSize];
        }
    }
}