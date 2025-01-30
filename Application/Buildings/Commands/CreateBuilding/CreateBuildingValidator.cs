using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Buildings.Commands.CreateBuilding;

public class CreateBuildingValidator : AbstractValidator<CreateBuildingRequest>
{
    public CreateBuildingValidator() => RuleFor(x => x.Name).Length(10, 30).NotEmpty();
}
