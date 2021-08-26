﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Comum
{
    public abstract class Base : Notifiable<Notification>
    {

        public Base()
        {
            Id = Guid.NewGuid();
            Data = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime Data { get; set; }
    }
}
