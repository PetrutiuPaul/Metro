using Application.Baskets.Command;
using Application.Interfaces.Repository;
using AutoFixture;
using Domain.Entities;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using static Application.Baskets.Command.AddItemCommand;

namespace Unit.Application
{
    public class AddItemCommandHandlerTests
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
                //arrange
                var basket = new Basket(_fixture.Create<string>(), true)
                {
                    Items = new List<Item>()
                };

                var item = new Item(_fixture.Create<string>(), _fixture.Create<decimal>(), basket.Id);
                
                var newBasket = new Basket(basket.Customer, true)
                {
                    Items = new List<Item>()
                    {
                        item
                    }
                };
                
                var substituteBasketRepository = Substitute.For<IBasketRepository>();
                substituteBasketRepository.Update(basket, default).Returns(Task.FromResult(newBasket));
                substituteBasketRepository.Get(basket.Id, default).Returns(basket);

                var addItemCommand = new AddItemCommand
                {
                    BasketId = basket.Id,
                    Item = item.Name,
                    Price = item.Price
                };

                var handler = new AddItemCommandHandler(substituteBasketRepository);

                //act
                await handler.Handle(addItemCommand, default);

                //assert
                await substituteBasketRepository.Received(1).Update(basket, default);
            }
        }
    }
}
