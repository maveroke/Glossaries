using System;
using Cirrious.CrossCore.Converters;

namespace Glossaries.Core
{
	public class StringLengthValueConverter:MvxValueConverter<string,string>
	{
		protected override string Convert (string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			value = value?? "";
			value = string.Concat("(", (500 - value.Length).ToString(), ")");
			return value;
		}
	}
}
