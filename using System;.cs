using System;
using Moq;
using Xunit;

public interface IDataService
{
    string GetData();
}

public class DataProcessor
{
    private readonly IDataService dataService;

    public DataProcessor(IDataService dataService)
    {
        this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
    }

    public string ProcessData()
    {
        string data = dataService.GetData();
        // Some data processing logic here
        return $"Processed: {data}";
    }
}

public class DataProcessorTests
{
    [Fact]
    public void ProcessData_WhenDataServiceReturnsValidData_ReturnsProcessedData()
    {
        // Arrange
        var mockDataService = new Mock<IDataService>();
        mockDataService.Setup(ds => ds.GetData()).Returns("Test data");

        var dataProcessor = new DataProcessor(mockDataService.Object);

        // Act
        string result = dataProcessor.ProcessData();

        // Assert
        Assert.Equal("Processed: Test data", result);
    }

    [Fact]
    public void ProcessData_WhenDataServiceThrowsException_ReturnsErrorMessage()
    {
        // Arrange
        var mockDataService = new Mock<IDataService>();
        mockDataService.Setup(ds => ds.GetData()).Throws(new Exception("Simulated exception"));

        var dataProcessor = new DataProcessor(mockDataService.Object);

        // Act
        string result = dataProcessor.ProcessData();

        // Assert
        Assert.Equal("Error processing data: Simulated exception", result);
    }
}
