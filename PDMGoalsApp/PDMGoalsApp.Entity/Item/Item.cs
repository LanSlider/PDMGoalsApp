using System;
using PDMGoalsApp.Entity.Base;

namespace PDMGoalsApp.Entity.Item
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Cost { get; set; }

        public СurrencyType CurrencyType { get; set; }


        public Guid CategoryId { get; set; }
    }
}
