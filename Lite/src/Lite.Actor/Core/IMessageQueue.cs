using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Actor.Core
{
    public interface IMessageQueue
    {
        void Push(Message msg);

        Message Pop();
    }
}
