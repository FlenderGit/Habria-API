using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.Common;
using MediatR;

namespace Application.Buildings.Commands.GenerateExcelBuilding;
public class GenerateExcelBuildingCommand(int id): IRequest<Fin<byte[]>>
{
    public int Id { get; } = id;
}
