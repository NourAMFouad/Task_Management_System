// See https://aka.ms/new-console-template for more information
using System;
using System.ComponentModel;
using System.Reflection;


namespace task_management{

// delegate declaration 
public delegate string Inputhandler(); 

    // to intialize and start program 
    class Program{
        private string description;
        
        public Program(){
            description=" ";
        }
        
        // function to allow user add description 
        
        public string AddDescription(){

            description = Console.ReadLine();

            return description;
        }


        // Menu: display list of all features allow user to select one of them.
         static void Menu(bool start, Inputhandler inputh){
         // publisher class
                             
          TaskManager taskmanager = new TaskManager();
          Program pr = new Program();
          
          // subscriber class
            EventImplementation handle = new EventImplementation();
              // add event
             taskmanager.SuccessfullyEvent += handle.MessageHandled;
            
    
          while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {           
                if (start){


                    // display list of choices:
                    Console.WriteLine("MENU:\n1.Add task\n2.View Task\n3.Mark completed task \n4.Delete Task\n5.Export Tasks to file");

                    // start to allow user enter number to select choice
                    Console.WriteLine("Enter your choice from list:");
                    int choice_number = Convert.ToUInt16(Console.ReadLine());   // to select numbers from range 0 to 2^16
                

                    switch (choice_number){
                        case 1:
                        // Add task
                        Console.WriteLine("Enter task description:");
                        // string? description = Console.ReadLine();
                        // taskmanager.AddTask(pr.AddDescription());
                           taskmanager.AddTask(inputh());
                        break;

                        case 2:
                        // View Task
                        taskmanager.DisplayList();
                            break;
                        case 3:
                        // Mark completed task 
                        Console.WriteLine("Enter task description that you want to change: ");
                        // string? des = Console.ReadLine();
                        // taskmanager.Change_Statu(des);
                        taskmanager.Change_Statu(inputh());
                            break;

                        case 4:
                        // Delete Task
                        Console.WriteLine("Enter task description that you want to delete: ");
                      
                        taskmanager.DeleteTask(inputh());
                            break;

                        case 5:
                        // Export Tasks to file 
                        // taskmanager.ExportTasksToXml("tasks.xml");
                        // Console.WriteLine("File created succesfully.");
                            break;
                    }
                }
            }
        }

// method to all user add 

        static void Main(string []args){
            // make user press enter to start using task management system 
            // Allow user to start using app by press enter button
           Console.WriteLine("Press Enter to start using task management system ...");

           while (Console.ReadKey().Key != ConsoleKey.Enter){
                // If key not enter, continue waiting..
                Console.WriteLine("Please, Press Enter to start using task management app ...");
           }

           // once enter is pressed, then start using features in project
            bool start = true;
           // Menu(start);
           // creates a new instance of the Program class  
           Inputhandler input = new Inputhandler(new Program().AddDescription);
           Menu(start, input);
        }
    }
}