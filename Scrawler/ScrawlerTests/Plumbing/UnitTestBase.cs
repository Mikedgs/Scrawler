using Moq;
using Ninject;
using Ninject.MockingKernel.Moq;

namespace ScrawlerTests.Plumbing
{
    public abstract class UnitTestBase<T>
    {
        private readonly MoqMockingKernel _mockingKernel;

        protected UnitTestBase()
        {
            _mockingKernel = new MoqMockingKernel();
        }

        protected T ClassUnderTest
        {
            get { return _mockingKernel.Get<T>(); }
        }

        protected Mock<TMock> GetMock<TMock>() where TMock : class
        {
            return _mockingKernel.GetMock<TMock>();
        }
    }
}
