using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using LibGit2Sharp;

namespace phpcmd
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string addressController = "app/controllers/";
                string addressModel = "app/models/";

                string[] cmd = {
                                    "create controller = make:controller-<name of controller>",
                                    "create model = make:model-<name of model>"
                                };

                foreach (string arg in args)
                {

                    //spliting string with separator
                    char[] separatorCmd = { ':','-' };
                    string[] spCmd = arg.Split(separatorCmd, StringSplitOptions.RemoveEmptyEntries);

                    char[] separatorSpace = { '-',':' };
                    string[] spSpace = arg.Split(separatorSpace, StringSplitOptions.RemoveEmptyEntries);

                    //assaign to string variable
                    string Maincmd = spCmd[0];
                    string Typecmd = spCmd[1];
                    string Namecmd = spSpace[2];

                    //Start Command
                    if (Maincmd == "help")
                    {
                        foreach (var item in cmd)
                        {
                            Console.Write(item + "\n");
                        }
                    }

                    if(Maincmd == "install"){

                        Console.Write("installing");
                        if(Typecmd != null){

                            //Repository.Clone("https://github.com/"+Typecmd+".git", Namecmd);
                            Repository.Clone("https://github.com/"+Typecmd+".git",Namecmd);
                        }

                    }

                    //Creating framework project
                    if(Maincmd == "create"){ //creating command name
                        Console.Write("Creating ");
                        if(Typecmd == "project"){
                            Console.Write("Project ");

                            if(Namecmd != null){
                                Console.Write(Namecmd);
                                //Create project
                                CreateProject.Create(Namecmd, Namecmd);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nProject Created Successfully...");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                   
                                }

                            }
                        }

                    


                    if (Maincmd == "make")
                    { //making command name

                        Console.Write("Creating ");

                        if (Typecmd == "controller")
                        {  //command name

                            Console.Write("Controller ");

                            if (Namecmd != null) //controller name
                            {
                                Console.Write(Namecmd);
                                CreateProject.CreateController(Namecmd,addressController);

                            }
                        } // controller


                        if (Typecmd == "model"){  //command name
                            Console.Write("Model ");

                            if (Namecmd != null)//model name
                            {
                                Console.Write(Namecmd);
                                CreateProject.CreateModel(Namecmd,addressModel);
                            }
                        } // model
                    }

                }
                //Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }       
            
        }
    }
}
