using System;
using DataManagement;

namespace BusinessLogic
{
    public class GetData : IGetData
    {

        public MainStore GetObject(Type type)
        {
            return (MainStore)TransferData.Transfer(typeof(MainStore));
        }
    }
}