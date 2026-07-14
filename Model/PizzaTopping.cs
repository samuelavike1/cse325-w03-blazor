namespace BlazingPizza
{
    public class PizzaTopping
    {
        public Topping Topping { get; set; } = new();

        public int ToppingId { get; set; }
        
        public int PizzaId { get; set; }
    }
}
