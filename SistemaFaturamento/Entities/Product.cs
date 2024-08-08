
namespace SistemaFaturamento.Entities
{
    internal class Product
    {

        // Atributos 
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }


        // Construtor
        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }


        // Metodos
        public double total()
        {
            return this.price * this.quantity;
        }

        public override string ToString()
        {
            string mensagem = $"Name: {this.name}\nPrice: ${this.price}\nQuantity: {this.quantity}";
            return mensagem;
        }
    }
}

