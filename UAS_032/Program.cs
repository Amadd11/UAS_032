using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_032
{
    class Node
    {
        public int noSiswa;
        public string name;
        public string kelas;
        public Node next;
        public Node prev;
    }
    class DoubleLinkedList
    {
        Node START;

        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int nis;
            string nm;
            string kls;
            Console.Write("\nEnter the roll number: ");
            nis = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Console.Write("\nEnter the class of the student: ");
            kls = Console.ReadLine();
            Node newNode = new Node();
            newNode.noSiswa = nis;
            newNode.name = nm;
            newNode.kelas = kls;

            if (START == null || nis <= START.noSiswa)
            {
                if ((START != null) && (nis == START.noSiswa))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START;
                current != null && nis >= current.noSiswa;
                previous = current, current = current.next)
            {
                if (nis == current.noSiswa)
                {
                    Console.WriteLine("\nDuplictae roll numbes not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                   rollNo != current.noSiswa; previous = current,
                   current = current.next) { }
            return (current != null);
        }
        public bool DellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;

        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of " + "roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noSiswa + " " + currentNode.name + " " + currentNode.kelas +"\n");
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of " + "roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next) { }

                while (currentNode != null)
                {
                    Console.Write(currentNode.noSiswa + " " + currentNode.name + " " + currentNode.kelas + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
   
    }
     class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list ");
                    Console.WriteLine("3. View all records in the ascending order of roll numbers");
                    Console.WriteLine("4. View all records in the descending order of roll numbers");
                    Console.WriteLine("5. Search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.Write("Enter your choicce (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter class number of the student" +
                                    "whose record is to be deleted:");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.DellNode(rollNo) == false)
                                    Console.Write("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + " deleted \n");
                            }
                            break;
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\n Enter the Roll Number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.noSiswa);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values enterde.");
                }
            }
        }
    }
}

//2. DoubleLinkedList
//3. TOP pada algoritma stack ialah data yang datang terakhir akan keluar pertama dan ini biasanya disebut Last in First Out (LIFO)
//4. Data yang dapat ditambahkan diakhir disebut REAR dan data yang dihapus dari yang paling terakhir disebut FRONT
//5. a. 5
//   b. 20,15,25,30,32,31,35,48,50,70,65,67,66,69,90,98,94,99 