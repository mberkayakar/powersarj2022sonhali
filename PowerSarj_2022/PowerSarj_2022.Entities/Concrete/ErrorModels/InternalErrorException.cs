using System;

namespace PowerSarj_2022.Entities.Concrete.ErrorModels
{
    public class InternalErrorException : Exception
    {
        public InternalErrorException(string message) : base(message)
        {

        }
    }
}
