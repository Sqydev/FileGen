class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the path to the folder you want the files to be created to(PATH/TO/FOLDER/):");
        string PatchToFolder = Console.ReadLine();

        Console.WriteLine("Enter the path to the orginal file(PATH/TO/FILE/frog.cs):");
        string PatchToOriginalFile = Console.ReadLine();

        Console.WriteLine("Enter the word to be replaced in the FILE:");
        string WordToReplace = Console.ReadLine();

        Console.WriteLine("Enter file type(with.):");
        string FileType = Console.ReadLine();

        Console.WriteLine("How many files do you want:");
        int NumberOfFiles = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter output FILE NAMES (one by one (press ENTER after every word):");
        List<string> OutputNames = new List<string>();
        RegList(OutputNames);

        Console.WriteLine("Enter output words in FILE (one by one (press ENTER after every word):");
        List<string> OutputWords = new List<string>();
        RegList(OutputWords);


        MakeFiles();



        void RegList(List<string> OutputList)
        {
            string OutputListInput;
            for (int i = 0; i < NumberOfFiles; i++)
            {
                OutputListInput = Console.ReadLine();

                OutputList.Add(OutputListInput);
            }
        }

        void MakeFiles()
        {
            for (int i = 1; i <= NumberOfFiles; i++)
            {
                string NewFileName = PatchToFolder + "\\" + OutputNames[i - 1] + FileType;
                string NewFile = PatchToFolder + "\\" + OutputNames[i - 1] + FileType;

                File.Copy(PatchToOriginalFile, NewFile);

                string text = File.ReadAllText(NewFile);
                text = text.Replace(WordToReplace, OutputWords[i - 1]);
                File.WriteAllText(NewFile, text);

                File.Move(NewFile, NewFileName);
            }
        }
    }
}
