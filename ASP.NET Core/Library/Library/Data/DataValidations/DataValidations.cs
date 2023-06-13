namespace Library.Data.DataValidations
{
	public static class DataValidations
	{
		public static class DataBookValidations
		{
			public const int TitleMinLength = 10;
			public const int TitleMaxLength = 50;

			public const int AuthorMinLength = 5;
			public const int AuthorMaxLength = 50;

			public const int DiscriptionMinLength = 5;
			public const int DiscriptionMaxLength = 5000;

			public const double RatingMinLength = 0.00;
			public const double RatingMaxLength = 10.00;
		}

		public static class DataCategoryValidations
		{
			public const int NameMinLength = 5;
			public const int NameMaxLength = 50;
		}
	}
}
