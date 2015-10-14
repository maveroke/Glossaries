using System;

namespace Glossaries.Model
{
	public class ErrorModel
	{
		public bool IsError { get; private set; }
		public string Message{ get; private set; }
		public ErrorModel (bool isError, string error)
		{
			this.IsError = isError;
			this.Message = error;
		}
	}
}

