using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;

namespace Api.Models
{
	//https://github.com/TahirNaushad/Fiver.Api.Sorting
	public static class IQueryableExtensions
	{
		public static IQueryable<T> Sort<T>(this IQueryable<T> source, string sortBy)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (string.IsNullOrEmpty(sortBy))
				throw new ArgumentNullException(nameof(sortBy));

			var sortExpression = string.Empty;

			var listSortBy = sortBy.Split(',');
			foreach (var item in listSortBy)
			{
				sortExpression += AdjustDirection(item) + ",";
			}

			sortExpression = sortExpression.Substring(0, sortExpression.Length - 1);

			try
			{
				source = source.OrderBy(sortExpression);
			}
#pragma warning disable CS0168 // Variable is declared but never used
			catch (ParseException ex)
#pragma warning restore CS0168 // Variable is declared but never used
			{
				// sortBy include field not part of the model
			}

			return source;
		}

		private static string AdjustDirection(string item)
		{
			if (!item.Contains(' '))
				return item; // no direction specified

			var field = item.Split(' ')[0];
			var direction = item.Split(' ')[1];

			switch (direction)
			{
				case "asc":
				case "ascending":
					return field + " ascending";

				case "desc":
				case "descending":
					return field + " descending";

				default:
					return field;
			};
		}
	}
}