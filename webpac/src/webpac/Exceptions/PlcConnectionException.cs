﻿using System;

namespace Webpac.Services
{
    internal class PlcConnectionException : Exception
    {
        public PlcConnectionException()
        {
        }

        public PlcConnectionException(string message) : base(message)
        {
        }

        public PlcConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}