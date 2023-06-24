namespace EcommerceWebApi.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }

    public Category Category { get; set; }
}