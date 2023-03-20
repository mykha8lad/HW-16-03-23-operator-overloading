using HW_14_03_23_exceptions;

namespace HW_16_03_23_operator_overloading
{
    internal class Program
    {
        static void compareStudents(Student firstStudent, Student secondStudent)
        {
            string resultMessage = "Student {0} {1} has a higher average score than student {2} {3}\n";

            if (firstStudent == null || secondStudent == null)
                throw new ArgumentException();

            if (firstStudent == secondStudent)
                Console.WriteLine("Average scores are equal");
            else if (firstStudent > secondStudent)
                Console.WriteLine(resultMessage, firstStudent.getLastname(), firstStudent.getName(), secondStudent.getLastname(), firstStudent.getName());
            else
                Console.WriteLine(resultMessage, secondStudent.getLastname(), secondStudent.getName(), firstStudent.getLastname(), firstStudent.getName());
        }
        static void compareGroups(Group firstGroup, Group secondGroup)
        {
            string resultMessage = "There are more students in group {0} than in group {1}\n";

            if (firstGroup == null || secondGroup == null)
                throw new ArgumentException();

            if (firstGroup == secondGroup)
                Console.WriteLine($"The number of students in group {firstGroup.getGroupName()} is equal to the number of students in group {secondGroup.getGroupName()}");
            else if (firstGroup > secondGroup)
                Console.WriteLine(resultMessage, firstGroup.getGroupName(), secondGroup.getGroupName());
            else
                Console.WriteLine(resultMessage, secondGroup.getGroupName(), firstGroup.getGroupName());
        }

        static void Main(string[] args)
        {

            #region Сравнение среднего балла двух студентов
            Student st = new Student("McDermott", "Joanny", "Desmond");
            Student st2 = new Student("Franecki", "Bertha", "Emmie");

            Console.WriteLine(st);
            Console.WriteLine(st2);

            compareStudents(st, st2);

            try
            {
                compareStudents(st, null);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Exception: {exc}\n");
            }
            #endregion

            #region Сравнение количества студентов в двух группах
            Group group1 = new Group();
            Group group2 = new Group();
            group2.setCountStudents(13);

            Console.WriteLine($"{group1.getGroupName()} - {group1.getCountStudents()} students");
            Console.WriteLine($"{group2.getGroupName()} - {group2.getCountStudents()} students");

            compareGroups(group1, group2);

            try
            {
                compareGroups(null, group2);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Exception: {exc}\n");
            }
            #endregion

        }
    }
}