namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
        void Start()
        {
            Person person = new Person();
            string name = ReadString("Enter your name: ");
            if (File.Exists($"{name}.txt"))
            {
                Console.WriteLine($"Nice to see you again, {name}!");
                Console.WriteLine("We have the following information about you:");
                person = ReadPerson($"{name}.txt");
                DisplayPerson(person);
            }
            else
            {
                Console.WriteLine($"Welcome {name}!");
                person = ReadPerson();
                WritePerson(person, $"{name}.txt");
                Console.WriteLine("Your data is written to file.");
            }
        }
        string ReadString(string question)
        {
            Console.Write(question);
            string value = Console.ReadLine();
            return value;
        }
        int ReadInt(string question)
        {
            Console.Write(question);
            int value = Convert.ToInt32(Console.ReadLine());
            return value;
        }
        Person ReadPerson()
        {
            Person person = new Person();
            person.name = ReadString("Enter your name: ");
            person.city = ReadString("Enter your city: ");
            person.age = ReadInt("Enter your age: ");
            return person;
        }

        void DisplayPerson(Person p)
        {
            Console.WriteLine($"Name    : {p.name}");
            Console.WriteLine($"City    : {p.city}");
            Console.WriteLine($"Age     : {p.age}");
        }

        void WritePerson(Person p, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(p.name);
            writer.WriteLine(p.city);
            writer.WriteLine(p.age);
            writer.Close();
        }

        Person ReadPerson(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            Person person = new Person();
            person.name = reader.ReadLine();
            person.city = reader.ReadLine();
            person.age = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            return person;
        }
    }
}
