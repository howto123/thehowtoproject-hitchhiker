using System.Diagnostics;

namespace Hitchhiker_Endpoint_V1.IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void Enpoints_Work()
        {
            //Arrange

            //Act
            Process notePad = new Process();
            notePad.StartInfo.FileName = "notepad.exe";
            notePad.StartInfo.Arguments = "ProcessStart.cs"; // if you need some
            notePad.Start();
        }
    }
}