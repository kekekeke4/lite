﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Json.Serialize
{
    public interface IJSONDeserialize
    {
        T Deserialize<T>(string jsonStr);
    }
}
