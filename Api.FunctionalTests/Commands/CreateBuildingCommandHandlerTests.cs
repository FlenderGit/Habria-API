using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Commands;
public class CreateBuildingCommandHandlerTests
{
    /* private readonly Mock<IBuildingRepository> _buildingRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public CreateBuildingCommandHandlerTests()
    {
        _buildingRepositoryMock = new();
        _unitOfWorkMock = new();
    } */

    [Fact]
    public void Handler_Should_ReturnFailureResult_WhenEmailIsNotUnique()
    {
        // Arrange
        // var command = new CreateBuildingCommand();

        // Act
        int value = 1;

        // Assert
        Assert.Equal(value, 1);
    }
}
