using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ocdata.Operations.Helpers.ResponseHelper;
using Usage.Application.Dtos;
using Usage.Application.Services;

namespace Usage.Application.Features.CategoryAttributes.Commands.SaveCategoryAttribute
{
    public class SaveCategoryAttributeCommandHandler : IRequestHandler<SaveCategoryAttributeCommand, Result<string>>
    {
        private readonly ICategoryAttributeService _categoryAttributeService;
        private readonly IMapper _mapper;
        private readonly ILogger<SaveCategoryAttributeCommandHandler> _logger;

        public SaveCategoryAttributeCommandHandler(ICategoryAttributeService categoryAttributeService, IMapper mapper, ILogger<SaveCategoryAttributeCommandHandler> logger)
        {
            _categoryAttributeService = categoryAttributeService ?? throw new ArgumentNullException(nameof(categoryAttributeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result<string>> Handle(SaveCategoryAttributeCommand request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<CategoryAttributeDto>(request);

            var entity = await _categoryAttributeService.Save(dto);

            if (entity == null)
                return await Result<string>.FailureAsync("CategoryAttribute already exists.");

            _logger.LogInformation(message: $"CategoryAttribute CategoryId:{entity.CategoryId}, AttributeId:{entity.AttributeId} is successfully created.");

            return await Result<string>.SuccessAsync($"CategoryAttribute CategoryId:{entity.CategoryId}, AttributeId:{entity.AttributeId} is successfully created.");
        }
    }
}
