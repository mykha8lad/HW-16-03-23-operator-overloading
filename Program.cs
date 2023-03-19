using HW_14_03_23_exceptions;

namespace HW_16_03_23_operator_overloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Student st = new Student();

			try
			{
				st.setSurname("");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
        }
    }
}