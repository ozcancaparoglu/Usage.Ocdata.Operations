using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ocdata.Operations.Helpers.ResponseHelper;
using Usage.Application.Dtos;
using Usage.Application.Services;

namespace Usage.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<string>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<CategoryDto>(request);

            var entity = await _categoryService.Update(dto);

            if (entity == null)
                return await Result<string>.FailureAsync($"Db does not contains record: {request.Id}-{request.Name}");

            _logger.LogInformation(message: $"Category {entity.Name}, {entity.DisplayName} updated successfully.");

            return await Result<string>.SuccessAsync($"{entity.Name} updated successfully.");

        }
    }
}
