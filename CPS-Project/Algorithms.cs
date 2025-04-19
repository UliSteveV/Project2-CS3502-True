using System.Runtime.CompilerServices;

public class Algorithms{
    public void SRTF(){
        int arrivalTime = 0;
        int burstTime = 0;
        List<Process> processes = new List<Process>();
        Console.WriteLine("Enter the number of processes:");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i =0; i<n; i++){
            Console.WriteLine("Enter the arrival time of process {0}:", i+1);
            try{
                arrivalTime = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException){
                Console.WriteLine("Invalid input. Please enter a valid integer for arrival time.");
                i--; // Decrement i to repeat the input for the same process
                continue; // Skip to the next iteration of the loop
            }
            
            Console.WriteLine("Enter the burst time of process {0}:", i+1);
            try{
                burstTime = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException){
                Console.WriteLine("Invalid input. Please enter a valid integer for burst time.");
                i--; // Decrement i to repeat the input for the same process
                continue; // Skip to the next iteration of the loop
            }
            processes.Add(new Process(i+1, arrivalTime, burstTime));
        }

        int complete = 0, time =0, idleTime=0;;
        Process current;

        while(complete<n){
            current = null;
            foreach(Process p in processes){
                if(p.GetArrivalTime() <= time && p.GetRemainingTime() > 0){
                    if(current == null || p.GetRemainingTime() < current.GetRemainingTime()){
                        current = p;
                    }
                }
            }

            if(current == null){
                idleTime++;
                time++;
                continue;
            }

            current.DecreaseRemainingTime(1);
            time++;
            if(current.GetRemainingTime() == 0){
                current.SetCompletionTime(time);
                current.SetTurnAroundTime(current.GetCompletionTime() - current.GetArrivalTime());
                current.SetWaitingTime(current.GetTurnAroundTime() - current.GetBurstTime());
                complete++;
            }
        }

        int totalTime = time;
        double cpuUtilization = ((double)(totalTime - idleTime) / totalTime) * 100;

        Console.WriteLine("Process ID\tArrival Time\tBurst Time\tCompletion Time\tTurn Around Time\tWaiting Time");
        foreach(Process p in processes){
            Console.WriteLine($"{p.GetId()}\t\t{p.GetArrivalTime()}\t\t{p.GetBurstTime()}\t\t{p.GetCompletionTime()}\t\t{p.GetTurnAroundTime()}\t\t\t{p.GetWaitingTime()}");
        }

        Console.WriteLine($"\nCpu Utilization: {cpuUtilization:F2}%");

    }
}
    
    