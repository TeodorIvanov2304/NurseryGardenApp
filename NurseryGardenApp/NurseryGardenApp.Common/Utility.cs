namespace NurseryGardenApp.Common
{
	public static class Utility
	{
		public static bool IsGuidValid(string? id, ref Guid parsedGuid)
		{

			if (String.IsNullOrWhiteSpace(id))
			{
				return false;
			}

			bool isGuidValid = Guid.TryParse(id, out parsedGuid);

			if (!isGuidValid)
			{
				return false;
			}

			return true;
		}
	}
}
