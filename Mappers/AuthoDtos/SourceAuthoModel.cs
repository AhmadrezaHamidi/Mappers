namespace Mappers.AuthoDtos
{
    public class SourceAuthoModel
    {
        public SourceAuthoModel(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class DestinationAuthoDTO  
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
