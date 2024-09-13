using Abc.Application.Contracts.Persistence;
using Abc.Application.Dtos;
using AutoMapper;
using MediatR;

namespace Abc.Application.Features.Empleados.Queries.Obtener
{
    internal sealed class ObtenerEmpleadoListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<ObtenerEmpleadoListQuery, List<EmpleadoDto>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<List<EmpleadoDto>> Handle(ObtenerEmpleadoListQuery request, CancellationToken cancellationToken)
        {
            var empleadoList = await _unitOfWork.EmpleadoRepository.ObtenerEmpleadosListAsync();

            return _mapper.Map<List<EmpleadoDto>>(empleadoList);
        }
    }
}
