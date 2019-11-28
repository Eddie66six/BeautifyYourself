using Core.Core.Domain;

namespace Core.Core.Application
{
    public class BaseApplication : ErrorEvent
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseApplication(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected bool Commit()
        {
            return _unitOfWork.Commit();
        }
    }
}
