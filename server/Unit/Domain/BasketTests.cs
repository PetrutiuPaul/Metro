using AutoFixture;
using Domain.Entities;
using Domain.Helpers.VAT;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Unit.Domain
{
    public class BasketTests
    {
        public class ApplyVat
        {
            private readonly Fixture _fixture;

            public ApplyVat()
            {
                _fixture = new Fixture();
            }

            [Fact]
            public void ApplyVatIfNeeded()
            {
                var basket = new Basket(_fixture.Create<string>(), true);

                basket.Items = new List<Item>()
                    {
                        new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id),
                        new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id),
                        new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id),
                        new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id)
                    };

                basket.TotalGross.Should().Be(VatHelper.ApplyVAT(basket.TotalNet));
            }


            [Fact]
            public void DontApplyVatIfNotNeeded()
            {
                var basket = new Basket(_fixture.Create<string>(), false);

                basket.Items = new List<Item>()
                    {
                        new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id),
                        new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id),
                        new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id),
                        new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id)
                    };

                basket.TotalGross.Should().Be(basket.TotalNet);
            }
        }
    }
}
