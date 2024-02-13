using NUnit.Framework;
using Moq;
using Homies.Controllers;
using Homies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;

namespace Homies.Tests
{
    [TestFixture]
    public class EventControllerTests
    {
        private Mock<IEventService> _mockEventService;
        private EventController _controller;

        [SetUp]
        public void Setup()
        {
            _mockEventService = new Mock<IEventService>();

            var user = new ClaimsPrincipal(new GenericPrincipal(new GenericIdentity("User"), null));
            _controller = new EventController(_mockEventService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext { User = user }
                }
            };
        }

        [Test]
        public async Task Add_ReturnsViewResult()
        {
            // Arrange - no additional arrangement is needed

            // Act - Call the action method being tested
            var result = await _controller.Add();

            // Assert - Verify the outcome of the action
            // Assert that the result is of the expected type (ViewResult)
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public async Task Join_UserNotJoined_ReturnsRedirectToActionResult()
        {
            // Step 1: Arrange - Set up the initial conditions for the test
            int eventId = 1;

            // Set up the mock behavior for the event service:
            // Assume the user is not already joined to the event
            _mockEventService.Setup(s => s.IsUserJoinedEventAsync(eventId, It.IsAny<string>())).ReturnsAsync(false);

            // Assume joining the event is successful
            _mockEventService.Setup(s => s.JoinEventAsync(eventId, It.IsAny<string>())).ReturnsAsync(true);

            // Step 2: Act - Perform the action being tested
            var result = await _controller.Join(eventId);

            // Step 3: Assert - Verify the outcome of the action
            // Assert that the result returned is of the expected type
            Assert.IsInstanceOf<RedirectToActionResult>(result);

            // Convert the result to RedirectToActionResult for further assertions
            var redirectResult = (RedirectToActionResult)result;

            // Assert that the action name and controller name in the redirect result are as expected
            Assert.AreEqual("Details", redirectResult.ActionName); // Correcting the expected action name
            Assert.AreEqual("Event", redirectResult.ControllerName); // Assuming the controller is named Event

        }


        [Test]
        public async Task Join_UserAlreadyJoined_ReturnsRedirectToActionResult()
        {
            // Step 1: Arrange - Set up the initial conditions for the test
            int eventId = 1;

            // Set up the mock behavior for the event service:
            // Assume the user is already joined to the event
            _mockEventService.Setup(s => s.IsUserJoinedEventAsync(eventId, It.IsAny<string>())).ReturnsAsync(true);

            // Step 2: Act - Perform the action being tested
            var result = await _controller.Join(eventId);

            // Step 3: Assert - Verify the outcome of the action
            // Assert that the result returned is of the expected type
            Assert.IsInstanceOf<RedirectToActionResult>(result);

            // Convert the result to RedirectToActionResult for further assertions
            var redirectResult = (RedirectToActionResult)result;

            // Assert that the action name and controller name in the redirect result are as expected
            Assert.AreEqual("Details", redirectResult.ActionName); // Adjust based on your actual controller logic
            Assert.AreEqual("Event", redirectResult.ControllerName); // Assuming the controller is named Event
        }

    }
}
