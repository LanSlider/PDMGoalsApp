using System;
using PDMGoalsApp.Entity.Base;
using ItemEntity = PDMGoalsApp.Entity.Item.Item;
using UserEntity = PDMGoalsApp.Entity.User.User;

namespace PDMGoalsApp.Entity.ShopCart
{
    public class ShopCart : BaseEntity
    {
        public int Amount { get; set; }

        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }

        public Guid ItemId { get; set; }


        public UserEntity User { get; set; }

        public ItemEntity Item { get; set; }
    }
}
