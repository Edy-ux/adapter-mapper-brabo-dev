namespace MapperVsAdapter.Application.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int Visible { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public  DateTimeOffset DateBirthDay { get; set; }
        public string Gender { get; set; }
        public string NameFather { get; set; }
        public string NameMother { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Country { get; set; }
    }
}
