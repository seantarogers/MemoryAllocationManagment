namespace CrossGenerationReferences
{
    public class Customer
    {
        private string name;

        private Order order;

        public void AddOrder(Order incomingOrder)
        {
            order = incomingOrder;
        }

        public void UpdateName(string updatedName)
        {
            name = updatedName;
        }
    }
}