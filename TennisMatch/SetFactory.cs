namespace TennisMatch
{
    public class SetFactory : ISetFactory
    {
        public ISet Create() => new Set();
    }
}