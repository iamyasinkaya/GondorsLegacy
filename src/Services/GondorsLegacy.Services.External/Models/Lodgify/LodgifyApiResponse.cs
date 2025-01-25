using System.Collections.Generic;

namespace GondorsLegacy.Services.External
{
    public class LodgifyApiResponse<T>
    {
        public int? Count { get; set; }
        public List<T> Items { get; set; }
    }
}