namespace DesignPattern.CQRS.Commands
{
    public class RemoveProductCommand
    {
        #region Constructor

        public RemoveProductCommand(int id)
        {
            Id = id;
        }

        #endregion

        public int Id { get; set; }
    }
}
