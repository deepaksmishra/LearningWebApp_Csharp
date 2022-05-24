namespace LWAJWTLOG.Models
{
	public class ExceptionHandling
	{

		public void MissingID()
		{
			Console.Write("Exception has occurred : ");
		}
		public void DatabaseValueFetchError()
        {
			Console.WriteLine("database Doesn't have value ");
        }

		public void InccoretInput()
        {
			Console.WriteLine("Given Input is wrong");
        }


	}
}
