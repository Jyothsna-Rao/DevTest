using DataAccessLayer.Infrastructure;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PaymentService : IPaymentService
    {
        
        private readonly IPaymentRepository _paymentRepository;
        private readonly IRepository<Payment> _genericRepository;



        public PaymentService(IPaymentRepository paymentRepository, IRepository<Payment> genericRepository)
        {
            _paymentRepository = paymentRepository;
            _genericRepository = genericRepository;


        }

        public async Task<Payment>  CreatePayment(Payment newPayment)
        {
            var accountBalance = CheckAccountBalance(newPayment.AccountID);

            newPayment.PaymentStatus = accountBalance >= newPayment.Amount ? "Pending" : "Closed";
            newPayment.Reason = accountBalance < newPayment.Amount ? "Not Enough Funds" : null;

            var result =  await _genericRepository.AddAsync(newPayment);
            return result;
        }

        public async Task<Payment> ProcessPayment(int paymentId)
        {
           
            var paymentToUpdate = _paymentRepository.GetById(x => x.ID == paymentId);
            if(paymentToUpdate.PaymentStatus != "Closed")
            {
                paymentToUpdate.PaymentStatus = "Processed";
                var result = await _paymentRepository.UpdateAsync(paymentToUpdate);
                _paymentRepository.UpdateAccountBalance(paymentToUpdate);

                return result;

            }
            else

            return paymentToUpdate;


        }


        public async Task<Payment> CancelPayment(int paymentId,string reason)
        {
            var paymentToCancel = _paymentRepository.GetById(x => x.ID == paymentId);

            if (paymentToCancel.PaymentStatus != "Processed")
            {
                paymentToCancel.PaymentStatus = "Closed";
                paymentToCancel.Reason = !String.IsNullOrEmpty(reason) ? reason : String.Empty;

                var result = await _paymentRepository.UpdateAsync(paymentToCancel);
               
                return result;

            }

            else
            {
                
                return paymentToCancel;
            }


        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return _paymentRepository.GetAll();
        }

        
        public Payment GetById(int paymentId)
        {
            return _genericRepository.GetById(x => x.ID == paymentId);
        }

        
        public decimal CheckAccountBalance(int accountId)
        {
            

           return  _paymentRepository.CheckAccountBalance(accountId);

           
        }
    }
}
