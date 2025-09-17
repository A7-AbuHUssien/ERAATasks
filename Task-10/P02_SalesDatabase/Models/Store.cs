namespace P02_SalesDatabase.Models;
public class Store
{
    public int StoreId { get; set; }
    public string Name { get; set; }

    public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
}