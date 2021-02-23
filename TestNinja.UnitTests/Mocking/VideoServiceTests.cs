using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>(); // we are telling to moq library that we want object that implmenets ifilereader
            _videoService = new VideoService(_fileReader.Object);
        }
        [Test]
        public void ReadVideoTitle_EmmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var result = _videoService.ReadVideoTitleViaProp();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError_ExampleofDIviaProp()
        {
            var service = new VideoService();
           service.FileReader = new FakeFileReaderTest();

            var result = service.ReadVideoTitleViaProp();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError_ExampleofDIviaConstructor()
        {
            var service = new ConstructorDependencyService(new FakeFileReaderTest());
            var result = service.ReadVideoTitleViaConstructor();
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
