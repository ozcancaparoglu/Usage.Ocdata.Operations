using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ocdata.Operations.Helpers.ResponseHelper;
using Usage.Application.Dtos;
using Usage.Application.Services;

namespace Usage.Application.Features.CategoryAttributes.Commands.UpdateCategoryAttribute
{
    public class UpdateCategoryAttributeCommandHandler : IRequestHandler<UpdateCategoryAttributeCommand, Result<string>>
    {
        private readonly ICategoryAttributeService _categoryAttributeService;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryAttributeCommandHandler> _logger;

        public UpdateCategoryAttributeCommandHandler(ICategoryAttributeService categoryAttributeService, IMapper mapper, ILogger<UpdateCategoryAttributeCommandHandler> logger)
        {
            _categoryAttributeService = categoryAttributeService ?? throw new ArgumentNullException(nameof(categoryAttributeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<string>> Handle(UpdateCategoryAttributeCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<CategoryAttributeDto>(request);

            var entity = await _categoryAttributeService.Update(dto);

            if (entity == null)
                return await Result<string>.FailureAsync($"Db does not contains record: CategoryAttribute(CategoryId:{request.CategoryId}, AttributeId:{request.AttributeId})");

            _logger.LogInformation(message: $"CategoryAttribute CategoryId:{entity.CategoryId}, AttributeId:{entity.AttributeId} updated successfully.");

            return await Result<string>.SuccessAsync($"CategoryId:{entity.CategoryId}, AttributeId:{entity.AttributeId} updated successfully.");
        }
    }
}
