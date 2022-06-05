using Ardalis.GuardClauses;

namespace Pdsl.Api.GauardClauseExtensions
{
    public static class PressReleaseGuard
    {
        public static Guid InvalidPressReleaseId(this IGuardClause guardClause, Guid input, string parameterName)
        {
            if(input == default || input == Guid.Empty)
            {
                throw new ArgumentException("Value cannot be empty", parameterName);
            }

            return input;
        }

        public static string InvalidPressReleaseTitle(this IGuardClause guardClause, string input, string parameterName)
        {
            if (input is null || (input.Length is < 10 or > 255))
            {
                throw new ArgumentException("The press release title must be between 10 and 255 characters long; inclusive", parameterName);
            }

            return input;
        }

        public static string InvalidPressReleaseDescription(this IGuardClause guardClause, string input, string parameterName)
        {
            if (input is null || (input.Length is < 100 or > 500))
            {
                throw new ArgumentException("The press release description must be between 100 and 500 characters long; inclusive", parameterName);
            }

            return input;
        }

        public static DateTime InvalidPressReleaseReleaseDate(this IGuardClause guardClause, DateTime input, string parameterName)
        {
            if(input == default)
            {
                throw new ArgumentException("Release date cannot be empty", parameterName);
            }

            if(input.Kind != DateTimeKind.Utc)
            {
                input = input.ToUniversalTime();
            }

            if(DateTime.UtcNow > input)
            {
                throw new ArgumentException("The release date cannot be in the past", parameterName);
            }

            return input;
        }
    }
}
