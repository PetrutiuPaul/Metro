using AutoFixture;
using FluentAssertions;
using System;
using Xunit;

namespace Unit.Domain
{
    public class TodoTests
    {
        public class SetAsDone
        {
            private readonly Fixture _fixture;

            public SetAsDone()
            {
                _fixture = new Fixture();
            }

            [Fact]
            public void Success()
            {
              
            }
        }
    }
}
