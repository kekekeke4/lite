using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Actor
{
    public abstract class Actor
    {
        public string Name { get; set; }

        public IActorRef Self { get; protected set; }

        public IActorContext Context { get; protected set; }

        protected abstract void Received(Message msg);
        
    }
}
