// See https://aka.ms/new-console-template for more information
using Mapster;



//var person = new Person
//{
//    Id = 1,
//    FirstName = "John",
//    LastName = "Doe",
//    BirthDate = new DateTime(1980, 1, 1)
//};

//var config = new TypeAdapterConfig();

//TypeAdapterConfig.GlobalSettings.Apply(config);

//// تعیین نحوه ترکیب FirstName و LastName به FullName
//config.NewConfig<Person, PersonDto>()
//    .Map(dest => dest.FullName, src => src.FirstName + " " + src.LastName);


//var personDto = person.Adapt<PersonDto>();

//Console.WriteLine($"Id: {personDto.Id}");
//Console.WriteLine($"Full Name: {personDto.FullName}");
//Console.WriteLine($"Age: {personDto.Age} years");

//Console.ReadLine();
//-----------------------------------------------------------------

    var person = new Person
    {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        BirthDate = new DateTime(1980, 1, 1)
    };

// تعیین نحوه ترکیب FirstName و LastName به FullName
TypeAdapterConfig<Person, PersonDto>.NewConfig()
    .Map(dest => dest.FullName, src => src.FirstName + " " + src.LastName);

var personDto = person.Adapt<PersonDto>();

Console.WriteLine($"Id: {personDto.Id}");
Console.WriteLine($"Full Name: {personDto.FullName}");
Console.WriteLine($"Age: {personDto.Age} years");

Console.ReadLine();

