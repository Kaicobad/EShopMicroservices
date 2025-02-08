﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class BadRequestException : Exception
    {
        public string Details { get; }

        public BadRequestException(string? message) : base(message)
        {
            Details = string.Empty; // Initialize Details to avoid CS8618
        }

        public BadRequestException(string? message, string? details) : base(message)
        {
            Details = details ?? string.Empty; // Initialize Details to avoid CS8618
        }
    }
}
