using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace phpcmd
{
   static class CreateProject
    {
               static string addressController = "app/controllers/";
               static string addressModel = "app/models/";

                public static void Create(string projectName, string address)
                {
                    if (!Directory.Exists(address))
                    {
                        Directory.CreateDirectory("app/controllers/");
                        Directory.CreateDirectory("app/models/");
                        Directory.CreateDirectory("app/views/");

                        Directory.CreateDirectory("system/libs/");
                        Directory.CreateDirectory("system/libs/");
                        Directory.CreateDirectory("system/libs/");
                        Directory.CreateDirectory("system/libs/");

                        Directory.CreateDirectory("config/");

                        Directory.CreateDirectory("resources/css/");
                        Directory.CreateDirectory("resources/js/");
                        



                        CreateLibrary(address);
                        CreateController("IndexController", addressController, true);
                        CreateModel("IndexModel", addressModel, true);

                    }

                }

                public static void CreateController(string controllerName,  string address, bool inf = false)
                {

                    if (!Directory.Exists(address))
                    {
                        Directory.CreateDirectory(address);
                    }

                    using (Stream s = File.Open(address + controllerName + ".php", FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        string view = "\"home\"";
                        sw.Write(@"<?php 

class " + controllerName + @" extends Controller{
	public function __construct(){
	 	parent::__construct();
	}

	public function home(){
	 	$this->load->view(" + view + @");
	}
}
?>");
                        if(inf  == false){
                        
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nController Created Successfully...");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                    }
                }//End CreateController

                public static void CreateModel(string modelName, string address, bool inf = false)
                {

                    if (!Directory.Exists(address))
                    {
                        Directory.CreateDirectory(address);
                    }

                    using (Stream s = File.Open(address + modelName + ".php", FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(@"<?php

class " + modelName + @" extends Model{
    public function __construct(){
        parent::__construct();
    }

    public function dataList($query){
        return $this->db->select($query);
    }
}


?>");
                        if (inf == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nModel Created Successfully...");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                    }
                }//End Create Model


                public static void CreateLibrary(string address)
                {
                    string Controller = GetFile(@"C:\sojeb\file\system\libs\Controller.php"); //end controller code

                    string Model = GetFile(@"C:\sojeb\file\system\libs\Model.php"); //end model code
                    string Database = GetFile(@"C:\sojeb\file\system\libs\Database.php"); //end database code
                    string Load = GetFile(@"C:\sojeb\file\system\libs\Load.php"); //end load code
                    string config = GetFile(@"C:\sojeb\file\config\dbconfig.php"); //end config code
                    string index = GetFile(@"C:\sojeb\file\index.php"); //end index code
                    string htaccess = GetFile(@"C:\sojeb\file\.htaccess"); //end htaccess code
                    string homepage = GetFile(@"C:\sojeb\file\app\views\home.php"); // homepage code


                    CreateFile("Controller","system/libs/",Controller);
                    CreateFile("Model", "system/libs/", Model);
                    CreateFile("Load", "system/libs/", Load);
                    CreateFile("Database", "system/libs/", Database);
                    CreateFile("dbconfig", "config/", config);
                    CreateFile("index", "", index);
                    CreateFile("home","app/views/",homepage);
                    CreatehtaFile(".htaccess", "", htaccess);
                }
                public static void CreateFile(string name, string address, string content)
                {
                    using (Stream s = File.Open(address + name + ".php", FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(content);

                    }
                }

                public static void CreatehtaFile(string name, string address, string content)
                {
                    using (Stream s = File.Open(address + name, FileMode.Create))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(content);

                    }
                }

                public static string GetFile(string url)
                {
                    WebRequest request = WebRequest.Create(url);
                    //execute the request
                    WebResponse response = request.GetResponse();
                    //read data via response stream
                    Stream resStream = response.GetResponseStream();
                    string tempString = null;
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    byte[] buf = new byte[60];

                    do
                    {
                        count = resStream.Read(buf, 0, buf.Length);
                        if (count != 0)
                        {
                            tempString = Encoding.ASCII.GetString(buf, 0, count);
                            sb.Append(tempString);
                        }

                    } while (count > 0);

                    return sb.ToString();
                }

   }
}
