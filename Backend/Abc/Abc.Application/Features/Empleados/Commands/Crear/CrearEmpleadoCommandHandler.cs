using Abc.Application.Contracts.Persistence;
using Abc.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Abc.Application.Features.Empleados.Commands.Crear
{
    internal sealed class CrearEmpleadoCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CrearEmpleadoCommand, int>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<int> Handle(CrearEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var empleado = _mapper.Map<Empleado>(request);

            _unitOfWork.Repository<Empleado>().AddEntity(empleado);

            var result = await _unitOfWork.Complete();

            return empleado.Id;
        }
    }
}
