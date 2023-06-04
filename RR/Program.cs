using System;
using System.Collections.Generic;
using System.Collections;

namespace RR
{
    public class Program
    {
        static void Main(String[] args)
        {
            Console.Write("Enter time quantum: ");
            var quan = Convert.ToInt32(Console.ReadLine());


            /*
             * 
            Console.Write("Enter process numbers: ");
            int num = Convert.ToInt32(Console.ReadLine());

            String pid;
            int at, obt;
             * 
             * var Processes = new List<ProcessItems>() { };
            for (int i = 0; i < num; i++)
            {
                Console.Write("Enter process name: ");
                pid = Console.ReadLine();
                Console.Write("Enter arrival time: ");
                at = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter burst or cpu time: ");
                obt = Convert.ToInt32(Console.ReadLine());
                Processes.Add(new ProcessItems() { PId = pid, AT = at, OBT = obt, BT = obt });
            }

            */


            /*
            var Processes = new List<ProcessItems>()
            {
                new ProcessItems(){ PId = "P1" , AT = 0, OBT = 8, BT = 8},
                new ProcessItems(){ PId = "P2" , AT = 5, OBT = 2, BT = 2},
                new ProcessItems(){ PId = "P3" , AT = 1, OBT = 7, BT = 7},
                new ProcessItems(){ PId = "P4" , AT = 6, OBT = 3, BT = 3},
                new ProcessItems(){ PId = "P5" , AT = 8, OBT = 5, BT = 5},
            };
            */
            /*
            var Processes = new List<ProcessItems>()
            {
                new ProcessItems(){ PId = "P1" , AT = 4, OBT = 5, BT = 5},
                new ProcessItems(){ PId = "P2" , AT = 0, OBT = 7, BT = 7},
                new ProcessItems(){ PId = "P3" , AT = 6, OBT = 9, BT = 9},
                new ProcessItems(){ PId = "P4" , AT = 10, OBT = 9, BT = 9}
            };
            */
            /*
            var Processes = new List<ProcessItems>()
            {
                new ProcessItems(){ PId = "P1" , AT = 0, OBT = 20, BT = 20},
                new ProcessItems(){ PId = "P2" , AT = 30, OBT = 17, BT = 17},
                new ProcessItems(){ PId = "P3" , AT = 20, OBT = 68, BT = 68},
                new ProcessItems(){ PId = "P4" , AT = 10, OBT = 24, BT = 24}
            };
            */



            //Questions starts from here.....
            //FALL-18, 3)c.Ans:- ...............
            /*
            var Processes = new List<ProcessItems>()
            {
                new ProcessItems(){ PId = "P1" , AT = 7, OBT = 12, BT = 12},
                new ProcessItems(){ PId = "P2" , AT = 5, OBT = 11, BT = 11},
                new ProcessItems(){ PId = "P3" , AT = 6, OBT = 9, BT = 9},
                new ProcessItems(){ PId = "P5" , AT = 0, OBT = 17, BT = 17},
                new ProcessItems(){ PId = "P4" , AT = 14, OBT = 13, BT = 13},
            };
            */

            //SPRING-18, 2)c.Ans:- ...............
            /*
            var Processes = new List<ProcessItems>()
            {
                new ProcessItems(){ PId = "P2" , AT = 0, OBT = 9, BT = 9},
                new ProcessItems(){ PId = "P0" , AT = 18, OBT = 15, BT = 15},
                new ProcessItems(){ PId = "P1" , AT = 8, OBT = 7, BT = 7},
                new ProcessItems(){ PId = "P3" , AT = 4, OBT = 18, BT = 18},
                new ProcessItems(){ PId = "P4" , AT = 16, OBT = 5, BT = 5},
                new ProcessItems(){ PId = "P5" , AT = 12, OBT = 5, BT = 5},
                new ProcessItems(){ PId = "P6" , AT = 22, OBT = 7, BT = 7},
            };
            */


            //SPRING-17, 7)c.Ans:- ...............
            /*
            var Processes = new List<ProcessItems>()
            {
                new ProcessItems(){ PId = "P1" , AT = 7, OBT = 12, BT = 12},
                new ProcessItems(){ PId = "P2" , AT = 5, OBT = 11, BT = 11},
                new ProcessItems(){ PId = "P3" , AT = 6, OBT = 9, BT = 9},
                new ProcessItems(){ PId = "P4" , AT = 0, OBT = 17, BT = 17},
                new ProcessItems(){ PId = "P6" , AT = 14, OBT = 13, BT = 13}
            };
            */


            //SPRING-20, 2)c.Ans:- ...............

            var Processes = new List<ProcessItems>()
            {
                new ProcessItems(){ PId = "P1" , AT = 5, OBT = 12, BT = 12},
                new ProcessItems(){ PId = "P2" , AT = 0, OBT = 11, BT = 11},
                new ProcessItems(){ PId = "P3" , AT = 4, OBT = 9, BT = 9},
                new ProcessItems(){ PId = "P4" , AT = 12, OBT = 17, BT = 17},
                new ProcessItems(){ PId = "P6" , AT = 35, OBT = 13, BT = 13}
            };

            // If 2 processes have the same arrival time then this will give error, as the queue will reamin empty at that time.............

            var SoArTi = new List<int>() { };

            for (int i = 0; i < Processes.Count; i++)
            {
                SoArTi.Add(Processes[i].AT);
            }

            SoArTi.Sort();

            var Processes2 = new List<ProcessItems>();

            for (int i = 0; i < Processes.Count; i++)
            {
                for (int j = 0; j < Processes.Count; j++)
                {
                    if (SoArTi[i] == Processes[j].AT)
                        Processes2.Add(new ProcessItems() { PId = Processes[j].PId, AT = Processes[j].AT, OBT = Processes[j].OBT, BT = Processes[j].OBT, Flag = 0 });
                }

            }

            /*
            var total_burst_time = 0;

            foreach (ProcessItems p in Processes2)
            {
                total_burst_time += p.BT;
            }
            */

            var ganch = new List<ProcessItems>();

            String pre_process = " ";
            String current_process = " ";

            int main_quan = 0;

            ganch.Add(new ProcessItems() { PId = Processes2[0].PId, ST = Processes2[0].AT, ET = Processes2[0].AT + quan });
            Processes2[0].BT = Processes2[0].BT - quan;
            Processes2[0].Flag = 1;
            pre_process = Processes2[0].PId;

            var readyqueue = new Queue();

            //var ready_pro = new List<String>();

            //Console.WriteLine($"The total burst time here is : {total_burst_time}");
            //Console.WriteLine($"{SoArTi.Count}");
            //Console.WriteLine($"{Processes2.Count}");

            //var reduced_burst = 0;

            //var ready_pos = 0;

            var total_loop_time = 0;

            for (int i = 0; i < Processes2.Count; i++)
            {
                if ((Processes2[i].OBT % quan) == 0)
                {
                    total_loop_time += Processes2[i].OBT / quan;
                }
                else
                {
                    total_loop_time += (int)Math.Ceiling((double)Processes2[i].OBT / quan);
                }
            }

            for (int m = 1; m < total_loop_time; m++)
            {
                for (int i = 1; i < SoArTi.Count; i++)
                {
                    if ((Processes2[i].AT < ganch[ganch.Count - 1].ET || Processes2[i].AT == ganch[ganch.Count - 1].ET) && Processes2[i].Flag != 1)
                    {
                        //ready_pro.Add(Processes2[i].PId);

                        readyqueue.Enqueue(Processes2[i].PId);
                        Processes2[i].Flag = 1;
                    }
                }

                foreach (ProcessItems p in Processes2)
                {
                    if (pre_process == p.PId && p.BT != 0)
                    {
                        //ready_pro.Add(p.PId);
                        readyqueue.Enqueue(p.PId);
                    }
                }

                current_process = (String)readyqueue.Dequeue();

                //current_process = ready_pro[ready_pos];

                foreach (ProcessItems p in Processes2)
                {
                    main_quan = quan;
                    if (current_process == p.PId)
                    {
                        if (p.BT < quan)
                        {
                            quan = p.BT;
                        }
                        ganch.Add(new ProcessItems() { PId = p.PId, ST = ganch[ganch.Count - 1].ET, ET = ganch[ganch.Count - 1].ET + quan });
                        p.BT = p.BT - quan;
                    }
                    if (p.BT != 0)
                    {
                        pre_process = current_process;
                    }
                    quan = main_quan;
                }

                //ready_pos++;

                /*
                foreach (ProcessItems p in Processes2)
                {
                    reduced_burst += p.BT;
                }

                total_burst_time -= reduced_burst;
               
                if (total_burst_time == 0)
                {
                    readyqueue.Enqueue(null);
                }
                */

            }


            Console.WriteLine();
            Console.WriteLine("The Ganttchart: ");
            Console.WriteLine();
            Console.Write("|");
            foreach (ProcessItems p in ganch)
            {
                Console.Write($"-{p.ST}--{p.PId}--{p.ET}-|");
            }

            Console.WriteLine();

            var starts = new List<int>();

            var ends = new List<int>();

            Console.WriteLine();

            double TWT = 0;
            double TTT = 0;

            for (int k = 0; k < Processes2.Count; k++)
            {
                for (int l = 0; l < ganch.Count; l++)
                {
                    if (ganch[l].PId == Processes2[k].PId)
                    {
                        starts.Add(ganch[l].ST);
                        ends.Add(ganch[l].ET);
                    }
                }
                if (Processes2[k].AT == 0)
                {
                    Processes2[k].WT = 0;
                }
                else
                {
                    Processes2[k].WT = starts[0] - Processes2[k].AT;
                }
                for (int i = 1; i < starts.Count; i++)
                {
                    int kl = i - 1;
                    Processes2[k].WT += starts[i] - ends[kl];
                }
                Processes2[k].TT = Processes2[k].WT + Processes2[k].OBT;
                TWT += Processes2[k].WT;
                TTT += Processes2[k].TT;

                starts.Clear();
                ends.Clear();
            }


            for (int k = 0; k < Processes2.Count; k++)
            {
                for (int l = 0; l < Processes.Count; l++)
                {
                    if (Processes2[k].PId == Processes[l].PId)
                    {
                        Processes[l].TT = Processes2[k].TT;
                        Processes[l].WT = Processes2[k].WT;
                    }
                }
            }


            foreach (ProcessItems item in Processes)
            {
                Console.WriteLine($"{item.PId} Waiting time: {item.WT} , Turnaround time: {item.TT}");
                Console.WriteLine();
            }

            var AVT = Convert.ToDouble(TWT) / Convert.ToDouble(Processes2.Count);
            var ATT = Convert.ToDouble(TTT) / Convert.ToDouble(Processes2.Count);

            Console.WriteLine();
            Console.WriteLine($"Average waiting time: {Math.Round(AVT, 3)}");
            Console.WriteLine();
            Console.WriteLine($"Average turnaround time: {Math.Round(ATT, 3)}");
        }
    }

    public class ProcessItems
    {
        public String PId { get; set; }

        public int AT { get; set; }

        public int OBT { get; set; }

        public int BT { get; set; }

        public int CT { get; set; }

        public int TT { get; set; }

        public int WT { get; set; }

        public int RT { get; set; }

        public int ST { get; set; }

        public int ET { get; set; }

        public int Flag { get; set; }

    }
}