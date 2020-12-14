namespace csBurgerShack.Models
{
  public class Burger
  {


    public string Title { get; set; }
    public int Price { get; set; }

    public string Toppings { get; set; }

    public bool IsAvailable { get; set; }

    public int Id { get; set; }
  }
}