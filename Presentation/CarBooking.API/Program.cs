using CarBooking.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBooking.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBooking.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBooking.Application.Features.CQRS.Handlers.CarHandlers;
using CarBooking.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBooking.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBooking.Application.Features.RepositoryPattern;
using CarBooking.Application.Interfaces;
using CarBooking.Application.Interfaces.BlogInterfaces;
using CarBooking.Application.Interfaces.CarDescriptionInterfaces;
using CarBooking.Application.Interfaces.CarFeatureInterfaces;
using CarBooking.Application.Interfaces.CarInterfaces;
using CarBooking.Application.Interfaces.CarPricingInterfaces;
using CarBooking.Application.Interfaces.CommentInterfaces;
using CarBooking.Application.Interfaces.RentACarInterfaces;
using CarBooking.Application.Interfaces.ReviewInterfaces;
using CarBooking.Application.Interfaces.StatisticInterfaces;
using CarBooking.Application.Interfaces.TagCloudInterfaces;
using CarBooking.Application.Services;
using CarBooking.Application.Validators.ReviewValidators;
using CarBooking.Persistence.Context;
using CarBooking.Persistence.Repositories;
using CarBooking.Persistence.Repositories.BlogRepositories;
using CarBooking.Persistence.Repositories.CarDescriptionRepositories;
using CarBooking.Persistence.Repositories.CarFeatureRepositories;
using CarBooking.Persistence.Repositories.CarPricingRepositories;
using CarBooking.Persistence.Repositories.CarRepositories;
using CarBooking.Persistence.Repositories.CommentRepositories;
using CarBooking.Persistence.Repositories.RentACarRepositories;
using CarBooking.Persistence.Repositories.ReviewRepositories;
using CarBooking.Persistence.Repositories.StatisticRepositories;
using CarBooking.Persistence.Repositories.TagCloudRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<CarBookingContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped<IStatisticRepository, StatisticRepository>();
builder.Services.AddScoped<IRentACarRepository, RentACarRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandsQueryHandler>();
builder.Services.AddScoped<GetCarByIdWithBrandQueryHandler>();
builder.Services.AddScoped<GetCarCountByBrandQueryHandler>();
builder.Services.AddScoped<GetCarDetailByIdWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<CreateReviewValidator>()
    .AddValidatorsFromAssemblyContaining<UpdateReviewValidator>(); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
