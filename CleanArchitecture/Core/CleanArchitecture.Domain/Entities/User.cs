using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class User
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}