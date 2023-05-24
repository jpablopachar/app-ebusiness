using System.Runtime.Serialization;

namespace Core.Entities.PurchaseOrder
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pendiente")]
        Pending,
        [EnumMember(Value = "El pago fue recibido")]
        PaymentReceived,
        [EnumMember(Value = "El pago tuvo errores")]
        PaymentFailed
    }
}