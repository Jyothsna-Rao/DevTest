using DataAccessLayer.Infrastructure;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IPaymentService 
    {
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> ProcessPayment(int PaymentId);
        Task<Payment> CancelPayment(int PaymentId, string reason);


        IEnumerable<Payment> GetAllPayments();


        Payment GetById(int PaymentId);


        decimal CheckAccountBalance(int AccountId);
    }
}
