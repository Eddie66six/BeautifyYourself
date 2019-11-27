using Core.Core;
using Core.Core.Domain;
using System;

namespace Core.Repository
{
    public class UnitOfWork : ErrorEvent, IUnitOfWork
    {
        private readonly Context _context;
        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                if (IsError()) return false;
                //_context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                AddError(e.Message, e.InnerException.Message);
                return false;
            }
        }
    }
}
