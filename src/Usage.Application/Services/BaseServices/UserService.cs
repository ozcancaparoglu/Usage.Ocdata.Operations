using AutoMapper;
using Ocdata.Operations.Authentication;
using Ocdata.Operations.Repositories.Contracts;
using Usage.Domain.UserAggregate;

namespace Usage.Application.Services.BaseServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<LoginModel> GetUserDetails(string accountName)
        {
            var entity = await _unitOfWork.Repository<UserDomain>().Find(x => x.Username == accountName);

            return _mapper.Map<UserModel>(entity);
        }

        public async Task<bool> IsValidUserInformation(string username, string password)
        {
            var entity = await _unitOfWork.Repository<UserDomain>().FindByProperties(x => x.Username == username
            && x.Password == password);

            return entity != null;
        }

    }
}
