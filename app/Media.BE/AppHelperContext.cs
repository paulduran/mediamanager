using System;
using System.Collections;

namespace Media.BE
{
    public interface AppHelperContext : IEnumerable
    {
        string[] InputFields { get; }
        string[] OutputFields { get; }
        object this[string fieldName] { get; set; }
    }
}
