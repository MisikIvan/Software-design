using WareHouseApp.Classes;
using WareHouseApp.Managers;
using WareHouseApp.Stores;

var wareHouse = new WareHouse();

var store = new Store();


var report = new Reporting(store);

var jsonReport  = new JsonReporting(store);




wareHouse.Manager = new WareHouseManager(wareHouse,report);




wareHouse.Manager.AddProduct(new Product {
    Name = "CS:GO",
    Id=1,
    Price = new Euro(),
    Category = new Category() { Id=2,Name="Game"}
});;
wareHouse.Manager.AddProduct(new Product {
    Name ="Nike Air", Id=12,
    Arrivas = new DateTime(2023,05,17),
    Price = new Dollar(),
    Unit = "pcs",
    Category = new Category()
    {
        Id = 1,
        Name="Snickers"
    }
});

wareHouse.Manager.AddProduct(new Product { 
    Name = "Nvidia 4080",
    Price = new Dollar(), Id = 4, 
    Category = new Category() 
    { 
        Id = 4, 
        Name = "GPU" 
    } 
});




report.GetProductCount();

wareHouse.Manager.RemoveProduct(4);

report.GetProductCount();

report.GetProfitableInvoice();

report.GetExpenseInvoice();
