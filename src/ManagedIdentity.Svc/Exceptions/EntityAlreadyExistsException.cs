namespace ManagedIdentity.Svc.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException()
            : base("An with same values already exists")
        {
        }
    }
}
