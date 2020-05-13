using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Задание_1
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            this.familyMembers = new List<Person>();
        }

        //Добавя човек в семейството
        public void AddFamilyMember(Person person)
        {
            this.familyMembers.Add(person);
        }

        //Премахва най-стария член на семейството.
        //Създава Person като бърка в листа с familyMembers
        //и ги сортира по възраст в низходящ ред и взима първия елемент от
        //листа тоест най-стария member. 
        public void RemoveOldestMember()
        {
            Person oldestPerson = this.familyMembers
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
            this.familyMembers.Remove(oldestPerson);
        }

        //Този метод си го направих за да тествам дали другите методи от заданието работят.
        public void ShowAllFamilyMembers()
        {
            foreach (var familyMember in this.familyMembers)
            {
                Console.WriteLine(familyMember);
            }
        }
        //Добавяне на хора в семейството.
        //Подават се бройакта хора може и да се направи директно в метода да се изисква бройакта хора.
        // въртим един for цикъл до бройката хора които трябва да добавим.
        // и стздаваме нов човек и го добавяме към семейството при всяко въртене.
        public void AddFamilyMembers(int count)
        {

            for (int i = 1; i <= count; i++)
            {
                Console.Write($"Member{i} name:");
                string memberName = Console.ReadLine();
                Console.Write($"Member{i} age:");
                int memberAge = int.Parse(Console.ReadLine());

                Person member = new Person(memberName, memberAge);

                this.familyMembers.Add(member);
            }
        }

        //Премахва всички членове на семейството над 30г.
        public void RemoveAllMembersAbove30()
        {
            familyMembers.RemoveAll(x => x.Age > 30);
        }

    }
}
