using Domain.Clientes;
using MediatR;

namespace Application.Clientes.Queries;

public class ObterClientesQuery : IRequest<List<Cliente>> { }
