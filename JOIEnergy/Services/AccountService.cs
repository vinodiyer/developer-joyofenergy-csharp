using System.Collections.Generic;
using JOIEnergy.Enums;

namespace JOIEnergy.Services
{
    public class AccountService : Dictionary<string, Supplier>, IAccountService
    { 
        private readonly Dictionary<string, Supplier> _smartMeterToPricePlanAccounts;

        public AccountService(Dictionary<string, Supplier> smartMeterToPricePlanAccounts) {
            _smartMeterToPricePlanAccounts = smartMeterToPricePlanAccounts;
        }

        public Supplier GetSupplierForSmartMeterId(string smartMeterId)
        {
            return
                !_smartMeterToPricePlanAccounts.ContainsKey(smartMeterId)
                    ? Supplier.NullSupplier
                    : _smartMeterToPricePlanAccounts[smartMeterId];
        }
    }
}
