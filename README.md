# Дз от 16/03/23. Operator overloading
## Реализовать перегрузку == для типа Student
___
### Перегрузка операторов в классе Student. Сравниваем по седнему баллу
```cs
public double getAverageMark()
{
    double avgMark = 0;
    avgMark += getListOffsets().Average() + getListHometasks().Average() + getListExams().Average();

    return avgMark;
}
```
```cs
public override int GetHashCode()
{
    return getAverageMark().GetHashCode();
}
public override bool Equals(object obj)
{
    Student student = obj as Student;
    if (student == null || GetType() != student.GetType()) { throw new ArgumentException(); }

    return this.getAverageMark() == student.getAverageMark();
}

public static bool operator ==(Student firstStudent, Student secondStudent)
{
    if (object.ReferenceEquals(firstStudent, secondStudent)) { return true; }

    if (object.ReferenceEquals(firstStudent, null) || object.ReferenceEquals(secondStudent, null)) { return false; }

    return firstStudent.getAverageMark() == secondStudent.getAverageMark();
}
public static bool operator !=(Student firstStudent, Student secondStudent)
{
    return !(firstStudent == secondStudent);
}

public static bool operator >(Student firstStudent, Student secondStudent)
{
    return firstStudent.getAverageMark() > secondStudent.getAverageMark();
}
public static bool operator <(Student firstStudent, Student secondStudent)
{
    return firstStudent.getAverageMark() > secondStudent.getAverageMark();
}

public static bool operator >=(Student firstStudent, Student secondStudent)
{
    return firstStudent.getAverageMark() > secondStudent.getAverageMark();
}
public static bool operator <=(Student firstStudent, Student secondStudent)
{
    return firstStudent.getAverageMark() > secondStudent.getAverageMark();
}
```
___
## Реализовать перегрузку == для типа Group
### Перегрузка операторов в классе Group. Сравниваем по количеству студентов в группе
```cs
public int getCountStudents()
{
    return this.studentsInGroup;
}
```
```cs
public override int GetHashCode()
{
    return getCountStudents().GetHashCode();
}
public override bool Equals(object obj)
{
    Group group = obj as Group;
    if (group == null || GetType() != group.GetType()) { throw new ArgumentException(); }

    return this.getCountStudents() == group.getCountStudents();
}

public static bool operator ==(Group firstGroup, Group secondGroup)
{
    if (object.ReferenceEquals(firstGroup, secondGroup)) { return true; }

    if (object.ReferenceEquals(firstGroup, null) || object.ReferenceEquals(secondGroup, null)) { return false; }

    return firstGroup.getCountStudents() == secondGroup.getCountStudents();
}
public static bool operator !=(Group firstGroup, Group secondGroup)
{
    return !(firstGroup == secondGroup);
}

public static bool operator >(Group firstGroup, Group secondGroup)
{
    return firstGroup.getCountStudents() > secondGroup.getCountStudents();
}
public static bool operator <(Group firstGroup, Group secondGroup)
{
    return firstGroup.getCountStudents() > secondGroup.getCountStudents();
}

public static bool operator >=(Group firstGroup, Group secondGroup)
{
    return firstGroup.getCountStudents() > secondGroup.getCountStudents();
}
public static bool operator <=(Group firstGroup, Group secondGroup)
{
    return firstGroup.getCountStudents() > secondGroup.getCountStudents();
}
```
___
## В main создаем две функции принимающие студентов и группы для сравнения
```cs
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
```
```cs
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
```
___
## Сравниваем а также ловим потенциальные исключительные ситуации
### Сравнение по среднему баллу двух студентов
```cs
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
```
### Сравнение групп по количеству студентов
```cs
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
```
___
## Результат:
[![result.jpg](https://i.postimg.cc/VLV8JWMM/result.jpg)](https://postimg.cc/qzyYYn1M)
