using System;

namespace PowerSarj_2022.Entities.Concrete.ErrorModels
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }   

    }

    public sealed class ItemNotFoundException : NotFoundException
    {
        public ItemNotFoundException(string message) : base(message + " id li istek bulunamadı".ToString())
        {

        }

    }
}
