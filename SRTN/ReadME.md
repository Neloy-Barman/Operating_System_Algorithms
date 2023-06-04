# Shortest Remaining Time First steps:
•	At first, I created a list ‘Process’ with all the processes with its properties. 
•	Then I entered the arrival times in an integer list ‘SoArTi’ & sorted it.
•	Then I took another list ‘Process2’ to enter the processes in a sorted order according to arrival times list.  
•	I took an empty list ‘ganch’ for the ganttchart containing processname, starting time and ending time. 
•	I took a queue named ’ts’ to keep track for the last rightside value entered in the ganttchart. 
•	The first process from the ‘Process2’ is entered directly into the ‘ganch’ & its arrival time is the starting time & ending time is the starting time incremented by 1. 
•	Then in the ganttchart, the last element’s ending time is enqueued in ‘ts’ for 3 times.
•	Then we run a for loop in the ‘Processes2’ list & dequeue from the ‘ts’, check the value with the arrival time of the element in ‘Processes2’. If they match, add value in ‘ganch’ list. Again dequeue 2 times from the ‘ts’ for the starting & ending value. After then in the ganttchart, the last element’s ending time is enqueued in ‘ts’ for 3 times. It happens till the for loop ends.
•	After then we clear the ‘SoArTi’ & again refill it using the BT values of the ‘Processes2’ list & sort it.
•	Then I just go through the process & simply follow the shortest job first done algorithm.    
•	Completion time for each process is what we have to check out from the right side of the gantt chart. We have to check the last time the process is added and the “to” value. Suppose if a process P1 runs from 20 to 22 secs. Then 22 is its to or completion time.
•	Turnaround time = Completion time – Arrival time
•	Waiting time = Turnaround time – original Burst/CPU time
•	Response time for each process is what we have to check out form the left side of the gantt chart. We have to check the first time the process is added to the chart & the from value. Suppose if a process P1 runs from 20 to 22 secs. Then 22 is its from.
Response time = From value – Arrival time.                   
