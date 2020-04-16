using NUnit.Framework;
using module3;
using Moq;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            /**
            C:\src\
            |---test1
                |---boot
                    boot.ini
                    test.exe
                |---src
            |---test2
            |---test3
                |---testresult
                |---func     
            */
        }

        [Test]
        public void Test1()
        {
            //Arrange
            var mock = new Mock<IFileSystemService>();
            mock.Setup(service => service.GetFiles(It.IsAny<string>())).Returns(new string[0]);
            mock.Setup(service => service.GetDirectories(It.IsAny<string>())).Returns(new string[0]);
            var visitor = new FileSystemVisitior(mock.Object);
            //Act
            var list = visitor.GetDirectories("startDir", "filter");
            //Assert
            Assert.AreEqual(0, list.Count);
        }
        [Test]
        public void Test2()
        {
            //Arrange
            var mock = new Mock<IFileSystemService>();
            mock.Setup(service => service.GetFiles(It.IsAny<string>())).Returns(new string[0]);
            _ = mock.Setup(service => service.GetDirectories("C:/src/")).Returns(new string[] { "test1", "test2", "test3" });
            _ = mock.Setup(service => service.GetDirectories("test1")).Returns(new string[] { "boot", "src" });
            var visitor = new FileSystemVisitior(mock.Object);
            //Act
            var list = visitor.GetDirectories("C:/src/", "test");
            //Assert
            Assert.AreEqual(3, list.Count);
        }
        [Test]
        public void Test3()
        {
            //Arrange
            var mock = new Mock<IFileSystemService>();
            mock.Setup(service => service.GetFiles("boot")).Returns(new string[] { "boot.ini", "test.exe", });
            _ = mock.Setup(service => service.GetDirectories("C:/src/")).Returns(new string[] { "test1", "test2", "test3" });
            _ = mock.Setup(service => service.GetDirectories("test1")).Returns(new string[] { "boot", "src" });
            var visitor = new FileSystemVisitior(mock.Object);
            //Act
            var list = visitor.GetDirectories("C:/src/", "test");
            //Assert
            Assert.AreEqual(4, list.Count);
        }
        [Test]
        public void Test4()
        {
            //Arrange
            var mock = new Mock<IFileSystemService>();
            _ = mock.Setup(service => service.GetDirectories("C:/src/")).Returns(new string[] { "test1", "test2", "test3" });
            _ = mock.Setup(service => service.GetDirectories("test1")).Returns(new string[] { "boot", "src" });
            mock.Setup(service => service.GetFiles("boot")).Returns(new string[] { "boot.ini", "test.exe", });
            _ = mock.Setup(service => service.GetDirectories("test3")).Returns(new string[] { "testresult", "func" });
            var visitor = new FileSystemVisitior(mock.Object);
            //Act
            var list = visitor.GetDirectories("C:/src/", "fiter");
            //Assert
            Assert.AreEqual(1, list.Count);
        }
    }
}
 