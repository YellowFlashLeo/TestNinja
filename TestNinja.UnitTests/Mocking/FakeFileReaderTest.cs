using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    public class FakeFileReaderTest : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
