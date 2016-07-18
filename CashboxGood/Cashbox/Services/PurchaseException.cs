using System;

namespace Cashbox.Services
{
    internal class PurchaseException : Exception
    {
        public readonly PurchaseError Error;

        public PurchaseException(PurchaseError error, string message = null) : base(message)
        {
            Error = error;
        }
    }
}
