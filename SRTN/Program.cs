using System;
using System.Collections;
using System.Collections.Generic;

namespace SRTN
{
    public class Program
    {
        static void Main(String[] args)
        {


            // For User inputs

            /*
            Console.Write("Enter process numbers: ");
            int num = Convert.ToInt32(Console.ReadLine());

            String pid;
            int at, obt;

            var Processes = new List<ProcessItems>() { };

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


            var Processes = new List<ProcessItems>()
            {
                new ProcessItems(){ PId = "P0", AT = 0, OBT = 8, BT = 8},
                new ProcessItems(){ PId = "P1" , AT = 1, OBT = 4, BT = 4},
                new ProcessItems(){ PId = "P2" , AT = 2, OBT = 2, BT = 2},
                new ProcessItems(){ PId = "P3" , AT = 3, OBT = 1, BT = 1}
            };

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
                        Processes2.Add(new ProcessItems() { PId = Processes[j].PId, AT = Processes[j].AT, OBT = Processes[j].OBT, BT = Processes[j].OBT });
                }

            }

            var ganch = new List<ProcessItems>();

            ganch.Add(new ProcessItems() { PId = Processes2[0].PId, ST = Processes2[0].AT, ET = 1 });

            Processes2[0].BT = Processes2[0].BT - 1;

            Queue ts = new Queue();

            //Queue readyqueue = new Queue();

            ts.Enqueue(ganch[ganch.Count - 1].ET);
            ts.Enqueue(ganch[ganch.Count - 1].ET);
            ts.Enqueue(ganch[ganch.Count - 1].ET);

            //readyqueue.Enqueue(Processes2[0].PId);

            for (int i = 1; i < Processes.Count; i++)
            {
                if ((int)ts.Dequeue() == Processes2[i].AT)
                {
                    //readyqueue.Enqueue(Processes2[i].PId);
                    ganch.Add(new ProcessItems() { PId = Processes2[i].PId, ST = (int)ts.Dequeue(), ET = (int)ts.Dequeue() + 1 });
                    Processes2[i].BT = Processes2[i].BT - 1;
                    ts.Enqueue(ganch[ganch.Count - 1].ET);
                    ts.Enqueue(ganch[ganch.Count - 1].ET);
                    ts.Enqueue(ganch[ganch.Count - 1].ET);
                }
                /*
                else
                {
                    ganch.Add(new ProcessItems() { PId = (String)readyqueue.Dequeue(), ST = (int)ts.Dequeue(), ET = (int)ts.Dequeue() + 1 });
                    readyqueue.Enqueue(ganch[ganch.Count - 1].PId);
                    for (int j = 0; j < Processes2.Count; j++)
                    {
                        if(ganch[ganch.Count - 1].PId == Processes2[j].PId)
                        {
                            Processes2[j].BT = Processes2[j].BT - 1;
                            ts.Enqueue(ganch[ganch.Count - 1].ET);
                            ts.Enqueue(ganch[ganch.Count - 1].ET);
                            ts.Enqueue(ganch[ganch.Count - 1].ET);
                        }
                    }
                }
                */
            }

            SoArTi.Clear();
            for (int i = 0; i < Processes2.Count; i++)
            {
                SoArTi.Add(Processes2[i].BT);
            }

            SoArTi.Sort();

            for (int i = 0; i < Processes2.Count; i++)
            {
                for (int j = 0; j < Processes2.Count; j++)
                {
                    if (SoArTi[i] == Processes2[j].BT && SoArTi[i] != 0)
                    {
                        ganch.Add(new ProcessItems() { PId = Processes2[j].PId, ST = ganch[ganch.Count - 1].ET, ET = ganch[ganch.Count - 1].ET + Processes2[j].BT });
                        Processes2[j].BT = 0;
                    }
                }
            }
            Console.WriteLine("The Ganttchart: ");
            Console.Write("|");
            foreach (ProcessItems p in ganch)
            {
                Console.Write($"-{p.ST}--{p.PId}--{p.ET}-|");
            }

            for (int i = 0; i < Processes2.Count; i++)
            {
                for (int j = ganch.Count - 1; j > -1; j--)
                {
                    if (Processes2[i].PId == ganch[j].PId)
                    {
                        Processes2[i].CT = ganch[j].ET;
                        break;
                    }
                }
            }

            for (int i = 0; i < Processes2.Count; i++)
            {
                for (int j = 0; j < ganch.Count - 1; j++)
                {
                    if (Processes2[i].PId == ganch[j].PId)
                    {
                        Processes2[i].RT = ganch[j].ST;
                        break;
                    }
                }
            }


            Console.WriteLine();
            foreach (ProcessItems p in Processes2)
            {
                p.TT = p.CT - p.AT;
                p.WT = p.TT - p.OBT;

                Console.WriteLine($" {p.PId}: AT {p.AT} , OBT {p.OBT}, BT {p.BT} , Completion {p.CT} , Waiting {p.WT} , Turn {p.TT} Response time {p.RT}");
            }

        }
    }

    public class ProcessItems
    {
        public String PId { get; set; }

        public int AT { get; set; }

        public int Priority { get; set; }

        public int OBT { get; set; }

        public int BT { get; set; }

        public int CT { get; set; }

        public int TT { get; set; }

        public int WT { get; set; }

        public int RT { get; set; }

        public int ST { get; set; }

        public int ET { get; set; }

    }
}