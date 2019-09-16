namespace Todo.Domain.Business
{
    public class Todo : Entity
    {
        public string Title { get; set; }

        public bool Completed { get; set; }
    }
}
