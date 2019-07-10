using System;
using PDMGoalsApp.Entity.Base;
using ItemEntity = PDMGoalsApp.Entity.Item.Item;
using UserEntity = PDMGoalsApp.Entity.User.User;

namespace PDMGoalsApp.Entity.Order
{
    public class Order : BaseEntity
    {
        public string CustomerName { get; set; }

        public string PhoneNumber { get; set; } 

        public string Address { get; set; }

        public DeliveryType DeliveryType { get; set; }

        public PayMethod PayMethod { get; set; }


        public Guid CategoryId { get; set; }

        public Guid UserId { get; set; }

        public Guid ItemId { get; set; }


        public UserEntity User { get; set; }

        public ItemEntity Item { get; set; }
    }
}
