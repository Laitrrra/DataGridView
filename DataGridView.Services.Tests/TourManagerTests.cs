using DataGridView.Entities;
using DataGridView.Services;
using FluentAssertions;
using Xunit;
using System;

namespace DataGridView.Services.Tests
{
    /// <summary>
    /// Unit-тесты для <see cref="InMemoryTourService"/>
    /// </summary>
    public class InMemoryTourServiceTests
    {
        private readonly InMemoryTourService service;

        public InMemoryTourServiceTests()
        {
            service = new InMemoryTourService();
        }

        /// <summary>
        /// Добавление тура должно присвоить Id и добавить тур в коллекцию
        /// </summary>
        [Fact]
        public void AddTour_ShouldAssignIdAndAddTour()
        {
            var tour = new Tour();

            service.AddTour(tour);

            tour.Id.Should().Be(1);
            service.GetAllTours().Should().ContainSingle(t => t.Id == 1);
        }

        /// <summary>
        /// Обновление существующего тура должно изменить его свойства
        /// </summary>
        [Fact]
        public void UpdateTour_ShouldUpdateExistingTour()
        {
            var tour = new Tour { PricePerPerson = 100 };
            service.AddTour(tour);

            var updatedTour = tour.Clone();
            updatedTour.PricePerPerson = 200;

            service.UpdateTour(updatedTour);

            service.GetAllTours()[0].PricePerPerson.Should().Be(200);
        }

        /// <summary>
        /// Обновление несуществующего тура не должно выбрасывать исключений
        /// </summary>
        [Fact]
        public void UpdateTour_ShouldDoNothingIfTourDoesNotExist()
        {
            var tour = new Tour { Id = 999, PricePerPerson = 100 };

            FluentActions.Invoking(() => service.UpdateTour(tour))
                         .Should().NotThrow();
            service.GetAllTours().Should().BeEmpty();
        }

        /// <summary>
        /// Удаление существующего тура должно удалить его из коллекции
        /// </summary>
        [Fact]
        public void DeleteTour_ShouldRemoveExistingTour()
        {
            var tour = new Tour();
            service.AddTour(tour);

            service.DeleteTour(tour.Id);

            service.GetAllTours().Should().BeEmpty();
        }

        /// <summary>
        /// Удаление несуществующего тура не должно выбрасывать исключений
        /// </summary>
        [Fact]
        public void DeleteTour_ShouldDoNothingIfTourDoesNotExist()
        {
            FluentActions.Invoking(() => service.DeleteTour(999))
                         .Should().NotThrow();
            service.GetAllTours().Should().BeEmpty();
        }

        /// <summary>
        /// Метод GetTotalTours должен вернуть корректное количество туров
        /// </summary>
        [Fact]
        public void GetTotalTours_ShouldReturnCorrectCount()
        {
            service.AddTour(new Tour());
            service.AddTour(new Tour());

            var total = service.GetTotalTours();

            total.Should().Be(2);
        }

        /// <summary>
        /// Метод GetTotalCost должен возвращать сумму всех туров с учётом доплат
        /// </summary>
        [Fact]
        public void GetTotalCost_ShouldReturnCorrectSum()
        {
            service.AddTour(new Tour { PricePerPerson = 100, NumberOfPeople = 2, Surcharges = 50 });
            service.AddTour(new Tour { PricePerPerson = 200, NumberOfPeople = 1, Surcharges = 0 });

            var totalCost = service.GetTotalCost();

            totalCost.Should().Be((100 * 2 + 50) + (200 * 1 + 0));
        }

        /// <summary>
        /// Метод GetToursWithSurcharges должен возвращать количество туров с доплатами
        /// </summary>
        [Fact]
        public void GetToursWithSurcharges_ShouldCountCorrectly()
        {
            service.AddTour(new Tour { Surcharges = 0 });
            service.AddTour(new Tour { Surcharges = 50 });
            service.AddTour(new Tour { Surcharges = 100 });

            var count = service.GetToursWithSurcharges();

            count.Should().Be(2);
        }

        /// <summary>
        /// Метод GetTotalSurcharges должен возвращать сумму всех доплат
        /// </summary>
        [Fact]
        public void GetTotalSurcharges_ShouldReturnCorrectSum()
        {
            service.AddTour(new Tour { Surcharges = 10 });
            service.AddTour(new Tour { Surcharges = 20 });

            var totalSurcharges = service.GetTotalSurcharges();

            totalSurcharges.Should().Be(30);
        }

        /// <summary>
        /// Метод GetAllTours должен возвращать все добавленные туры
        /// </summary>
        [Fact]
        public void GetAllTours_ShouldReturnAllAddedTours()
        {
            var t1 = new Tour();
            var t2 = new Tour();
            service.AddTour(t1);
            service.AddTour(t2);

            var tours = service.GetAllTours();

            tours.Should().BeEquivalentTo(new[] { t1, t2 });
        }
    }
}
