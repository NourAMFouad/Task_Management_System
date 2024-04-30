// declare delegate for event handler
using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
//using System.Xml.Serialization;

public delegate void SuccessfullyEventHandler();

    // to control and manage tasks
    class TaskManager{   
        // declare event using delegate 
        public event SuccessfullyEventHandler? SuccessfullyEvent;

        // create memeber and modify list to store all tasks that will create 
        private List<Task> tasks;
        private string description;

        // constructor, to initialize list
        public TaskManager(){ 
            tasks =  new List<Task>();
            description = " ";
            
        }

        // Function to add new task and store it in list
        public bool AddTask(string description){
            // add new task and make statu by default is pending 
            // 1.create object 
            Task task = new Task(description, Taskstatus.Pending);
            // 2.add new object in list
             tasks.Add(task);
            SuccefullyMessageHandled();
             if (tasks.Contains(task)){
              
                return true; 
             }else{
                return false;
             }


        }
        
        // handling event logic
        public void SuccefullyMessageHandled(){
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        SuccessfullyEventHandler handler = SuccessfullyEvent;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        if (handler != null){
             handler();
            }
        }

        // function to display all tasks from list
        public void DisplayList(){
            if (tasks.Count == 0){
                Console.WriteLine("No tasks available");
            }else {
            Console.WriteLine("Tasks:");
            foreach (var task in tasks){
                Console.WriteLine($"- {task.Description} [{task.Status}]");
            }
            }
        }

        
       
        // function to change status of task 
        // allow user to enter description of task and search of it to change of statu 
        public void Change_Statu(string descr){
             bool found = false;
            // ask user wich statu want to change it 
            Console.WriteLine("To make task completed press 1 and to make it in progress press 2.\n");
          
            // instance to check key 
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            foreach (var task in tasks){
                // search task that user want to change it
                if (task.Description == descr){
                    
                    found = true;
                   

                    // when press 1 make statue = completed 
                    if (keyInfo.Key == ConsoleKey.D1 || keyInfo.Key == ConsoleKey.NumPad1){
                        task.Status = Taskstatus.Completed;
         
                    // when press 2 make statue = in progress
                    }else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.NumPad2){
                        task.Status = Taskstatus.InProgress;
                      
                    // when press another key print error message  
                    }else {
                        Console.WriteLine("Try Again.\n");
                    }
            }        
               // when task not in list
                if (found == false){
                   Console.WriteLine("please try agian, task not in list.\n");
                }else if (found == true){
                   Console.WriteLine("Done\n");
                }
            

        }            

        }
       

public void DeleteTask(string desc)
{
    // check if task found in tasks and delelted or not 
    Task? taskToRemove = null;

    // find task when user enter description 
    foreach (var task in tasks){
        // 
        if (task.Description == desc){
           taskToRemove = task; 
           break;
        }

    }

    // check if we find task and delete it 
    if (taskToRemove != null){
        tasks.Remove(taskToRemove);
        Console.WriteLine("Deleted task successfully.");
    } else{
        Console.WriteLine($"Not found any task with {desc} name");
    }

}



// to export tasks in data in pdf file 
// 1 export tasks list to write it in xml file 
// public void ExportTasksToXml (string filePath){
//     // create filestream to write xml file
//     using (FileStream filestream = new FileStream(filePath, FileMode.Create)){
//         // create xmlSerializer for List tasks type
//         XmlSerializer serializer = new XmlSerializer(typeof(List<Task>));
    
//         // Serialize the list of tasks and write it to file
//         serializer.Serialize(filestream, tasks);
//     }
// }



    }   // end of TaskManager class



    /**
    
        // Use RemoveAll method with a predicate to remove all tasks matching the description
    int initialCount = tasks.Count;
    tasks.RemoveAll(task => task.Description.Equals(desc, StringComparison.OrdinalIgnoreCase));

    // Check if any tasks were removed
    int removedCount = initialCount - tasks.Count;
    if (removedCount > 0)
    {
        // Inform the user that tasks have been deleted
        Console.WriteLine($"{removedCount} task(s) with description '{desc}' deleted successfully.");
    }
    else
    {
        // If no tasks were removed
        Console.WriteLine($"No task found with description '{desc}'.");
    }
    */