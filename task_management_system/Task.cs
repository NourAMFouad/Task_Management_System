// To save status values 
enum Taskstatus
{
    Pending, InProgress, Completed
}



// include all info related with task details 

class Task{
    public string Description { get; set; } 
    public Taskstatus Status { get; set; }

    // constructor with zero args
    // why it required for serialization 
    public Task(){

    }
    // constructor
    // note make paarmeters lowercase and variable on it with uppercase
    public Task(string description, Taskstatus status){
        Description = description;
        Status = status;
    } 

    
}