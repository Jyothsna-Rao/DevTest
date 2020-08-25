using BusinessLayer;
using DataAccessLayer;
using DataAccessLayer.Infrastructure;
using DataAccessLayer.Repositories;
using DemoTestApplication.Controllers;
using DemoTestApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace DemoTestApplication.API.UnitTests
{
    public class PaymentRepositoryTest
    {


        [Fact]
        public void Get_TestClassObjectPassed_ProperMethodCalled()
        {
            var options = new DbContextOptionsBuilder<DevTestContext>().UseInMemoryDatabase(databaseName: "Payments Test")
        .Options;

            using (var context = new DevTestContext(options))
            {
                context.Payment.Add(new Payment { ID = 1, Amount = 100, PaymentDate = System.DateTime.Now, AccountID = 2 });
                context.SaveChanges();
            }
            using (var context = new DevTestContext(options))
            {
               //Arrange
                var repo = new Repository<Payment>(context);

                //method
              
                var payment = repo.GetById(x => x.ID == 1);
           

                Assert.Equal(1, payment.ID);
            }

            

        }

       


        
    }
}
