using System.Diagnostics;
using Application.Buidings.Queries.GetBuilding;
using Application.Buildings.Commands.GenerateExcelBuilding;
using Application.Buildings.Queries.GetBuilding;
using Application.Buildings.Queries.GetBuildingFilters;
using Application.Buildings.Queries.GetBuildings;
using Application.Common.Models;
using Application.Observation.Queries.GetObservation;
using FluentValidation;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppHost.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildingController(ISender _mediator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetBuildings([FromQuery] PaginatedQuery request)
    {
        var command = new GetBuildingsQuery(request);
        PaginatedList<BuildingViewDTO> result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("chapters")]
    public async Task<IActionResult> GetBuildingFilters()
    {
        var command = new GetBuildingFiltersQuery();
        List<TypeChapitreDto> result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("observation/{id:int}")]
    public async Task<IActionResult> GetObservation([FromRoute] int id)
    {
        var command = new GetObservationQuery(id);
        Option<ObservationDTO> result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            Some: value => Ok(value),
            None: () => NotFound()
        );
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBuilding([FromRoute] int id)
    {
        var command = new GetBuildingQuery(id);
        Option<BuildingDTO> result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            Some: value => Ok(value),
            None: () => NotFound()
        );
    }

    [HttpGet("{id:int}/excel")]
    public async Task<IActionResult> GetExcelRecapFromBuilding([FromRoute] int id)
    {
        var command = new GenerateExcelBuildingCommand(id);
        Fin<byte[]> fileByte = await _mediator.Send(command);

        string filename = "building_report.xlsx";

        return fileByte.Match<IActionResult>(
            Succ: v => File(v, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename),
            Fail: e => NotFound(e)
        );
    }

    // [HttpPost]
    // public IActionResult Create([FromBody] CreateBuildingRequest request) => Ok(request);
}
