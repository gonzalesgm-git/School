using MediatR;
using School.Domain.Dto.Response;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Queries.Applications
{
    public record ApplicationListQuery(): IRequest<IEnumerable<ApplicationInfo>>;
    internal class ApplicationListQueryHandler : IRequestHandler<ApplicationListQuery, IEnumerable<ApplicationInfo>>
    {
        private IApplicationRepository _repository;
        public ApplicationListQueryHandler(IApplicationRepository repository)
        {
            _repository = repository;  
        }

        
        public async Task<IEnumerable<ApplicationInfo>> Handle(ApplicationListQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetApplicationInfo();
            return res;
        }
    }
}
