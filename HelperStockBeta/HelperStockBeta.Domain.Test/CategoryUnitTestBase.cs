using FluentAssertions;
using HelperStockBeta.Domain.Entities;

namespace HelperStockBeta.Domain.Test
{
    #region Casos de testes positivos
    public class CategoryUnitTestBase
    {
        [Fact(DisplayName ="Category name is not null")]
        public void CreateCategory_WithValidParameters_ResultValid()
        {
            Action action= () => new Category(1, "Categoria teste");
            action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Category not present id parameter")]
        public void CreateCategory_IdParameterLess_ResultValid()
        {
            Action action = () => new Category("Categoria teste");
            action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion

    #region Casos de testes negativos
        [Fact(DisplayName = "Is negative exception")]
        public void CreateCategory_NegativeParameterId_ResultException()
        {
            Action action = () => new Category(-1, "Categoria teste");
            action.Should().Throw <HelperStockBeta.Domain.Validation.DomainExceptionValidation >()
                .WithMessage("Identification is positive values!");
        }
        [Fact(DisplayName = "Name in Category null")]
        public void CreateCategory_NameParameterNull_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required!");
        }
        [Fact(DisplayName = "Name short for Category null")]
        public void CreateCategory_NameParameterShort_ResultException()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name is minimum 3 charecters");
        }
        #endregion
    }
}