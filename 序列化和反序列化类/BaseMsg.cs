using System;
using System.Collections.Generic;
public class BaseMsg : BaseData
{
    public override int GetBytesNum()
    {
        throw new NotImplementedException();
    }

    public override int Reading(byte[] bytes, int beginIndex = 0)
    {
        throw new NotImplementedException();
    }

    public override byte[] Writing()
    {
        throw new NotImplementedException();
    }

    public virtual int GetID()
    {
        return 0;
    }
}
