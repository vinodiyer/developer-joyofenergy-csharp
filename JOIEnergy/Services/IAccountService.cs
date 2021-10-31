using JOIEnergy.Enums;

namespace JOIEnergy.Services
{
    public interface IAccountService
    {
        Supplier GetSupplierForSmartMeterId(string smartMeterId);
    }
}