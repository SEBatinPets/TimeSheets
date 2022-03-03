using DomainLibrary.Domain.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models.DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeSheets.Controllers;
using Xunit;

namespace TimeSheetsTestsProject.UserController
{
    public class DeleteTests
    {
        [Fact]
        public void Delete_return_Ok()
        {
            var tokent = new CancellationToken();
            var userManager = new Mock<IUsersManager>();
            userManager.Setup(
                x => x.DeleteByIdAsync(It.IsAny<int>(), tokent)
                ).Returns(Task.FromResult(200));

            var userController = new UsersController(userManager.Object);
            var result = userController.Delete(It.IsAny<int>(), tokent).Result;

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
