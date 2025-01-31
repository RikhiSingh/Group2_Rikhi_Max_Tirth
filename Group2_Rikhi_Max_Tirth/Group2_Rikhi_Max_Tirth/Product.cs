namespace Group2_Rikhi_Max_Tirth;

public class Product
{
    public int ProdID { get; set; }
    public string ProdName { get; set; }
    public decimal ItemPrice { get; set; }
    public int StockAmount { get; set; }

    public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
    {
        if (stockAmount < 0)
            throw new ArgumentException("Stock amount cannot be negative.");

        if (itemPrice < 0)
            throw new ArgumentException("Item price cannot be negative.");

        ProdID = prodID;
        ProdName = prodName ?? throw new ArgumentNullException(nameof(prodName));
        ItemPrice = itemPrice;
        StockAmount = stockAmount;
    }

    public void IncreaseStock(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount to increase must be positive.");
        
        StockAmount += amount;
    }

    public bool DecreaseStock(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount to decrease must be positive.");

        if (amount > StockAmount)
            return false; // Cannot reduce below zero

        StockAmount -= amount;
        return true;
    }
}
