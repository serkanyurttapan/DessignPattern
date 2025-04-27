// See https://aka.ms/new-console-template for more information


/*
* FluentBuilder pattern : Bir nesnenin adım adım(ve okunabilir şekilde) oluşturulmasını sağlayan bir tasarım desenidir.
* Özelliği şu; Metotlar birbirlerine zincirlenerek (method chaining) çağrılır ve nesne inşası daha okunaklı,
daha kontrollü hale gelir.
 */

using System.Text.Json;

var order = new Order.Builder().SetCustomerName("serkan").SetAddress("icerenkoy").Build();

Console.WriteLine(JsonSerializer.Serialize(order));

public class Order
{
    public string CustomerName { get; private set; }
    public string Address { get; private set; }
    public string Note { get; private set; }
    public string ShippingMethod { get; private set; }
    
    private Order() {}
    
    public class Builder
    {
        private readonly Order _order = new Order();

        public Builder SetCustomerName(string name)
        {
            _order.CustomerName = name;
            return this;
        }

        public Builder SetAddress(string address)
        {
            _order.Address = address;
            return this;
        }

        public Order Build()
        {
            return _order;
        }
    }


}