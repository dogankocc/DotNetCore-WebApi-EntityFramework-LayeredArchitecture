using System;

namespace Model
{
    public class BaseEntity
    {

        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
