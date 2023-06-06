using PaternsImpl;
using PaternsImpl.AbsctractFactoryMethod;
using PaternsImpl.AbsctractFactoryMethod.Factories;
using PaternsImpl.AbsctractFactoryMethod.Interfaces;
using PaternsImpl.Builder;
using PaternsImpl.FactoryMethod.Apps;
using PaternsImpl.FactoryMethod.Classes;
using PaternsImpl.FactoryMethod.CustomEventArgs;
using PaternsImpl.FactoryMethod.Entities;
using PaternsImpl.FactoryMethod.Interfaces;
using PaternsImpl.FactoryMethod.Repositories;
using PaternsImpl.Prototype;
using PaternsImpl.Singletone;



var subFactory = new SubscribeFactory();

var store = new Store();

store.Subscribes.Add(subFactory.CreateSubscribe(1));
store.Subscribes.Add(subFactory.CreateSubscribe(2));
store.Subscribes.Add(subFactory.CreateSubscribe(3));

var repo = new SubscribeRepository(store);

var manager = new SubsсriptionManager(repo);

var appFactory =  new AppFactory();

store.Users.Add(new User() { Id = 1, Name = "John" });


Console.WriteLine("1.Enter to mobile app 2.Enter to website 3.Call to manager");
string? choice = Console.ReadLine();

switch (choice)
{
    case "1": {
            MobileApp mobileApp = (MobileApp)appFactory.CreateApp("MobileApp", manager);
            mobileApp.Run();
            mobileApp.InitUser(store.Users.First());
            mobileApp.ShowInterface();
        }
       break;
    case "2":
        {
            WebSite webApp = (WebSite)appFactory.CreateApp("WebSiteApp", manager);
            webApp.Run();
        }
        break;
    case "3":
        {
            ManagerCall app = (ManagerCall)appFactory.CreateApp("ManagerCall", manager);
            app.Run();
        }
        break;
    default: throw new Exception("App does not exist");
}













