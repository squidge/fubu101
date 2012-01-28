namespace fubu101.ModelsValidators
{
    using FluentValidation;

    using fubu101.Handlers.Movie.Add;

    public class MovieValidator: AbstractValidator<AddInputModel>
    {
        public MovieValidator()
        {
            RuleFor(prop => prop.Title).NotEmpty();
            RuleFor(prop => prop.Year).NotEmpty();
        }
    }
}