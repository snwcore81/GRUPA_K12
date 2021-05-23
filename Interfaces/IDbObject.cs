using System;
using System.Collections.Generic;
using System.Text;

namespace GRUPA_K12.Interfaces
{
    public interface IDbObject
    {
        bool Exists(IDbSource Source);
        bool Select(IDbSource Source);
        bool Insert(IDbSource Source);
        bool Update(IDbSource Source);
        bool Delete(IDbSource Source);
    }
}
