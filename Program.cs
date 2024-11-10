// See https://aka.ms/new-console-template for more information
Menu();

static void Menu(){
  Console.Clear();
  Console.WriteLine("What do you want to do?");
  Console.WriteLine("1. Open a file");
  Console.WriteLine("2. Create a new file");
  Console.WriteLine("0. Exit");

  short option = short.Parse(Console.ReadLine());

  switch(option){
    case 1:
      OpenFile();
      break;
    case 2:
      CreateFile();
      break;
    case 0:
      Environment.Exit(0);
      break;
    default:
      Console.WriteLine("Invalid option. Please try again.");
      Thread.Sleep(1000);
      Menu();
      break;
  }

}

static void OpenFile(){
  Console.Clear();
  Console.WriteLine("Enter the path to the file:");
  var path = Console.ReadLine();

  using (var file = new StreamReader(path))
  {
    string text = file.ReadToEnd();
    Console.WriteLine(text);
  }

  Console.WriteLine("");
  Console.ReadLine();
  Menu();
}

static void EditFile(string initialText = ""){
  Console.Clear();
  Console.WriteLine("Write your text below (ESC to exit)");
  Console.WriteLine("---------------------");
  string text = initialText;

  do {
    text += Console.ReadLine();
    text += Environment.NewLine;
  }
  while(Console.ReadKey(true).Key != ConsoleKey.Escape);

  SaveFile(text);
}

static void CreateFile(){

  EditFile();
}

static void SaveFile(string text)
{
  Console.Clear();
  Console.WriteLine("What is the path to save the file?");
  var path = Console.ReadLine();

  using (var file = new StreamWriter(path))
  {
    file.Write(text);
  }

  Console.WriteLine($"The file {path} has been saved.");
  Console.ReadLine();
  Menu();
}
