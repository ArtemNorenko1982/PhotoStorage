using System.Collections.Generic;
using PhotoStorage.Contracts;

namespace PhotoStorage.Common
{
    public static class GlobalDataStorage
    {
        public static List<PhotoItem> Photos { get; set; } = new List<PhotoItem>();
    }
}
