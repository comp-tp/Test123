﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.PubSub
{
    public interface IMessageEntity
    {
        string TopicName { get; set;}
    }
}