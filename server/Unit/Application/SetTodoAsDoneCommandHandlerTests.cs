using AutoFixture;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Application
{
    public class SetTodoAsDoneCommandHandlerTests
    {
        public class Handle
        {
            private readonly Fixture _fixture;

            public Handle()
            {
                _fixture = new Fixture();
            }

            [Fact]
            public async Task Success()
            {

            }

            [Fact]
            public async Task IdDoesntExists_ThrowException()
            {

            }
        }
    }
}
