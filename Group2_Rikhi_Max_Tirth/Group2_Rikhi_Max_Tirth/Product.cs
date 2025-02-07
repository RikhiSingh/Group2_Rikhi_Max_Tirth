using System;

namespace ECommerceApp
{
    public class Product
    {
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; private set; }

        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            if (prodID < 5 || prodID > 50000)
                throw new ArgumentException("Product ID must be between 5 and 50000.");

            if (itemPrice < 5 || itemPrice > 5000)
                throw new ArgumentException("Item price must be between $5 and $5000.");

            if (stockAmount < 5 || stockAmount > 500000)
                throw new ArgumentException("Stock amount must be between 5 and 500000.");

            ProdID = prodID;
            ProdName = prodName ?? throw new ArgumentNullException(nameof(prodName));
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount to increase must be positive.");

            if (StockAmount + amount > 500000)
                throw new ArgumentException("Stock amount cannot exceed 500,000.");
            StockAmount += amount;
        }

        public bool DecreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount to decrease must be positive.");

            if (amount > StockAmount)
                return false; // Prevent stock from going negative

            StockAmount -= amount;
            return true;
        }
    }
}