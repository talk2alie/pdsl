using Ardalis.GuardClauses;

namespace Pdsl.Api.GauardClauseExtensions
{
    public static class GuidGuard
    {
        public static void InvalidPressReleaseId(this IGuardClause guardClause, Guid input, string parameterName)
        {
            if(input == default || input == Guid.Empty)
            {
                throw new ArgumentException("Value cannot be empty", parameterName);
            }
        }
    }
}
