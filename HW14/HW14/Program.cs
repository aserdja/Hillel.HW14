using LibraryPlatform.Data;
using LibraryPlatform.Models;
using LibraryPlatform.Repositories;
using LibraryPlatform.Services;
using System.Runtime.InteropServices;

using var context = new LibraryPlatformDbContext();
var br = new BookRepository(context);
var brr = new BookRentalRepository(context);
var ur = new UserRepository(context);

var bs = new BookService(br);
var brs = new BookRentalService(br, brr);

var user1 = ur.GetAll().Result.First();
var user2 = ur.GetAll().Result.Last();

var book1 = br.GetByTitle("1984").Result.First();
var book2 = br.GetByTitle("Atlant").Result.First();

Console.WriteLine(await brs.CheckBookAvailability(book1, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(3))); 
await brs.RentBook(user1, book1, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(3));
Console.WriteLine(await brs.CheckBookAvailability(book1, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(3))); 
await brs.RentBook(user2, book1, DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(3));
await brs.RentBook(user2, book2, DateTime.Now.Date.AddDays(3), DateTime.Now.Date.AddDays(5));
await brs.RentBook(user2, book1, DateTime.Now.Date.AddDays(6), DateTime.Now.Date.AddDays(10));

