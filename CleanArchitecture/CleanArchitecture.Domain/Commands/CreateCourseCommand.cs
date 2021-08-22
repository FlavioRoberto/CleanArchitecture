namespace CleanArchitecture.Domain.Commands
{
    public class CreateCourseCommand : CourseCommand
    {
        public CreateCourseCommand(string name, string description, string imgUrl)
        {
            Name = name;
            Description = description;
            ImageUrl = imgUrl;
        }
    }
}
