using System;
using System.Collections.Generic;

namespace Задание_1
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.Write("Member name:");
            string memberName = Console.ReadLine();
            Console.Write("Member age:");
            int memberAge = int.Parse(Console.ReadLine());

            try
            {
                Person member1 = new Person();
                Person member2 = new Person(memberAge);
                Person member3 = new Person(memberName, memberAge);

                Console.WriteLine(member1);
                Console.WriteLine(member2);
                Console.WriteLine(member3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Person member = new Person("Dido", 25);

            Console.Write("Members count:");
            int familyMembersCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            family.AddFamilyMember(member);

            family.AddFamilyMembers(familyMembersCount);

            Console.WriteLine($"All family members.");
            family.ShowAllFamilyMembers();

            family.RemoveOldestMember();

            Console.WriteLine($"Family members after RemoveOldestMember.");
            family.ShowAllFamilyMembers();

            family.RemoveAllMembersAbove30();

            Console.WriteLine($"Family members after RemoveAllMembersAbove30.");
            family.ShowAllFamilyMembers();

            
        }
    }
}
