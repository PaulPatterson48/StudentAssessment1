

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>
{
    new Product() {Name = "Saxophone", Price = 599.99M, ProductTypeId = 1},
    new Product() {Name = "Trombone", Price = 550.00M, ProductTypeId = 1},
    new Product() {Name = "Trumpet", Price = 725.99M, ProductTypeId = 1},
    new Product() {Name = "Tuba", Price = 4000.00M, ProductTypeId = 1},
    new Product() {Name = "French Horn", Price = 589.00M, ProductTypeId = 1},
    new Product() {Name = "Beethoven", Price = 17.00M, ProductTypeId = 2},
    new Product() {Name = "Song of Myself", Price = 23.00M, ProductTypeId = 2},
    new Product() {Name = "The Idea of Order at Key West", Price = 15.00M, ProductTypeId = 2},

};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new()
{
    new ProductType() { Id = 1, Title = "Brass"},
    new ProductType() { Id = 2, Title = "Poem"}
};
//put your greeting here
Console.WriteLine("Welcome to Brass And Poem Store by Paul Patterson.");

//implement your loop here


{

    DisplayMenu();
    Console.Write("Enter your choice(1,2,3,4,5): ");
    int choice = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (choice)
    {
        case '1':
            DisplayAllProducts(products, productTypes);
            break;
        case '2':
            DeleteProduct(products, productTypes);
            break;
        case '3':
            AddProduct(products, productTypes);
            break;
        case '4':
            UpdateProduct(products, productTypes);
            break;
        case '5':
            Console.WriteLine("Exiting the program.");
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
    while (choice != 5) ;

} 

void DisplayMenu()
{
    Console.WriteLine("\nOptions: ");
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update a new product");
    Console.WriteLine("5. Exit");
}    

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId);
        Console.WriteLine($"{i + 1}. Name: {products[i].Name}, Price: {products[i].Price:C}, Product Type: {productType?.Title}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products,productTypes);

    Console.Write("Enter the index of the product to delete: ");
    if (int.TryParse(Console.ReadLine(), out int index))
    {
        products.RemoveAt(index - 1);
        Console.WriteLine("Product deleted successfully.");
    }
    else
    {
        Console.WriteLine("Invalid index. Please enter a valid index.");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nEnter details for the new product: ");
    Console.Write("Name: ");
    string productName = Console.ReadLine();

    Console.Write("Price: ");
    if (decimal.TryParse(Console.ReadLine(), out decimal productPrice))
    {
        Console.WriteLine("Avaiable Product Type:");
        DisplayAllProductTypes(productTypes);

        Console.Write("Enter Product Type ID: ");
        if (int.TryParse(Console.ReadLine(), out int productTypeId))
        {
            if (productTypes.Any(pt => pt.Id == productTypeId))
            {
                Product newProduct = new Product()
                {
                    Name = productName,
                    Price = productPrice,
                    ProductTypeId = productTypeId
                };

                products.Add(newProduct);

                Console.WriteLine("Product added successfully.");                
            }
        }
        else
        {
            Console.WriteLine("Invalid Product Type Id. Please enter a Product Id of 1 or 2");
        }
    }
    
}
void DisplayAllProductTypes(List<ProductType> productsTypes)
{
    foreach (var productType in productsTypes)
    {
        Console.WriteLine($"Product Type Id: {productType.Id}, Title: {productType.Title}");
    }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.Write("Enter the index of the product to update: ");
    if(int.TryParse(Console.ReadLine(), out int index))
    {
        if (index >= 1 && index <= products.Count)
        {
            Product existingProduct = products[index - 1];
            Console.WriteLine("\nEnter new details for the product:");

            Console.Write("Name: ");
            string newName = Console.ReadLine();

            Console.Write("Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
            {
                Console.WriteLine("Available Product Types:");
                DisplayAllProductTypes(productTypes);

                Console.Write("Enter Product Type ID:");
                if (int.TryParse(Console.ReadLine(), out int newProductTypeId))
                {
                    if (productTypes.Any(pt => pt.Id == newProductTypeId))
                    {
                        existingProduct.Name = newName;
                        existingProduct.Price = newPrice;
                        existingProduct.ProductTypeId = newProductTypeId;

                        Console.WriteLine("Product updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product Type Id. Please enter a valid Product Type Id");
                    }
                }

            }
        }
    }
    
}


// don't move or change this!
public partial class Program { }