namespace cs341.Structures
{
    public class Item
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        decimal? SalePrice { get; set; }
    }
}