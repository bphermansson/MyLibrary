// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7034/");
HttpResponseMessage message = client.GetAsync("api/Users").Result;
string returnText = message.Content.ReadAsStringAsync().Result;
Console.WriteLine(returnText);
Console.ReadLine();
