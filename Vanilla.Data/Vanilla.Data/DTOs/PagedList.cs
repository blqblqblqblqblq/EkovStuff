using System;
using System.Collections.Generic;

namespace Vanilla.Data.DTOs
{
    public class PagedList<T>
    {
        public List<T> Objects { get; set; }
        public int TotalCount { get; set; }
    }
}
