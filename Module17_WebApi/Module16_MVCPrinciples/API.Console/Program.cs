using System.Net;


GetAllProductData();
Console.ReadLine();
static void GetAllProductData()
{
    using var client = new WebClient(); //WebClient  
   
    Console.WriteLine("All products");
    client.Headers.Add("Content-Type:application/json"); //Content-Type  
    client.Headers.Add("Accept:application/json");
    var result = client.DownloadString("https://localhost:7109/api/products"); //URI  
    Console.WriteLine(Environment.NewLine + result);
    
}