﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class BasketNotFoundException : Exception
    {
        public BasketNotFoundException(int basketId) : base($"No basket found with id {basketId}")
        {
        }

        protected BasketNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public BasketNotFoundException(string message) : base(message)
        {
        }

        public BasketNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
