using System.Diagnostics.Contracts;

/// <summary>
/// This class represents a process in a scheduling algorithm simulation.
/// </summary>
public class Process{
    private int Id;
    private int ArrivalTime;
    private int BurstTime;
    private int CompletionTime;
    private int TurnAroundTime;
    private int WaitingTime;
    private int RemainingTime;

    public Process(int id, int arrivalTime, int burstTime){
        Id = id;
        ArrivalTime = arrivalTime;
        BurstTime = burstTime;
        CompletionTime = 0;
        TurnAroundTime = 0;
        WaitingTime = 0;
        RemainingTime = burstTime;
    }

    /// <summary>
    /// Getters and Setters for the process' attributes.
    /// </summary>
    /// <returns></returns>
    public int GetId(){
        return Id;
    }
    public int GetArrivalTime(){
        return ArrivalTime;
    }
    public int GetBurstTime(){
        return BurstTime;
    }
    public int GetCompletionTime(){
        return CompletionTime;
    }
    public int GetTurnAroundTime(){
        return TurnAroundTime;
    }
    public int GetWaitingTime(){
        return WaitingTime;
    }
    public int GetRemainingTime(){
        return RemainingTime;
    }
    public void SetCompletionTime(int completionTime){
        CompletionTime = completionTime;
    }
    public void SetTurnAroundTime(int turnAroundTime){
        TurnAroundTime = turnAroundTime;
    }
    public void SetWaitingTime(int waitingTime){
        WaitingTime = waitingTime;
    }
    public void SetRemainingTime(int remainingTime){
        RemainingTime = remainingTime;
    }
    public void DecreaseRemainingTime(int time){
        RemainingTime -= time;
    }
    //end of getters and setters

    /// <summary>
    /// Resets the remaining time of the process to its burst time.
    /// </summary>
    public void ResetRemainingTime(){
        RemainingTime = BurstTime;
    }

    /// <summary>
    /// Prints the process' attributes to the console.
    /// </summary>
    public void PrintProcess(){
        Console.WriteLine($"Process ID: {Id}, Arrival Time: {ArrivalTime}, Burst Time: {BurstTime}, Completion Time: {CompletionTime}, Turn Around Time: {TurnAroundTime}, Waiting Time: {WaitingTime}, Remaining Time: {RemainingTime}");
    }
}