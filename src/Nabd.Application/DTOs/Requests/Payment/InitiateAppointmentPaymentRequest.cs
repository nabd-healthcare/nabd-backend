using System.ComponentModel.DataAnnotations;
using Nabd.Core.Enums.Payment;

namespace Nabd.Application.DTOs.Requests.Payment
{
    public class InitiateAppointmentPaymentRequest
    {
        [Required(ErrorMessage = "طريقة الدفع مطلوبة")]
        public PaymentMethod PaymentMethod { get; set; }

        /// <summary>
        /// نوع الدفع الإلكتروني: Card (بطاقة) أو MobileWallet (فودافون كاش)
        /// </summary>
        public PaymentType PaymentType { get; set; } = PaymentType.Card;
    }
}
