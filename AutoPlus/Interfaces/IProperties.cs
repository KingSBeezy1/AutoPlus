using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPlus.Interfaces
{
    public interface IProperties
    {
        int Id { get; set; }
        string InjectionType { get; set; }
    }
}
