using System;

namespace BusinessLogic
{
    public interface IGetData
    {
        MainStore GetObject(Type type);
    }
}