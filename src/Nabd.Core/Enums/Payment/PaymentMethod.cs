using System.ComponentModel;

namespace Nabd.Core.Enums.Payment
{
    /// <summary>
    /// طريقة الدفع الرئيسية
    /// </summary>
    public enum PaymentMethod
    {
        [Description("دفع إلكتروني عبر Paymob")]
        Online = 1,

        [Description("كاش عند الاستلام")]
        CashOnDelivery = 2
    }
}
