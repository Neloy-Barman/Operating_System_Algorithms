# Round Robin algorithm code explanation: 
* At first, I created a list ‘Process’ with all the processes with its properties. 
* Then take input for the time quantum ‘quan’.
* Then I entered the arrival times in an integer list ‘SoArTi’ & sorted it.
* Then I took another list ‘Process2’ to enter the processes in a sorted order according to arrival times list. I sorted the list to enter the first element in the ‘ganch’       
* I took an empty list ‘ganch’ for the ganttchart containing processname, starting time and ending time. 
* I took 2 String variables named pre_process =” ” and current_process = ” ”.
* The first process from the ‘Process2’ is entered directly into the ‘ganch’ & its arrival time is the starting time & ending time is the starting time + time quantum. Then its burst time is decremented & the flag is set to 1.
* We are setting the flag = 1, so that after every addition in the ganttchart we are checking the main list for the arrival time. If the flag != 1. Then check it else discard.
* The we take a queue named ‘readyqueue’.
* Now we are dividing each’s original burst time by the time quantum. If the remainder is 0, then add the result to the total_loop_time else make the result ceiling & add it to the total_loop_time. As, every process in the ganttchart contains time limit less than 3 or totally 3. So, we can count for how much the processes will be switched before completing the tasks.
* Now a loop < total_loop_time starts. Checking the list’s process’s arrival time with ganttchart’s last element’s ending time. If it’s less or equal then enqueued in the ‘readyqueue’ & the flag of that element is set to 1.
* Again, a loop starts & checking the ‘pre_process’ with list element, if it’s burst_time isn’t 0, then added to the readyqueue.
* Then a process is dequeued & added to the current_process.
* A loop runs through the ‘Processes2’ list & if the current_process = Process_Id, then added to the ganttchart & checked. If its BT=0 or not. If BT isn’t 0, then it’s added to the pre_preocess. & the loop continues till the iteration reaches total_loop _time.
* For each Process_Id whenever it matches in the ganttchart, we are taking its starting time to the starts list & ending time to ends list. Then substitute the arrival time form the first element of the starts + ends[i] – starts[i-1].
That’s the waiting time. 
Turnaround time is equal to the waiting time + original_burst_time.      


