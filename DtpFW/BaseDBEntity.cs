using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DtpFW
{
    public abstract class BaseDBEntity
    {
    }
    public abstract class BaseDBEntityCollection<T> : List<T> where T : BaseDBEntity, new()
    {
    }
}
