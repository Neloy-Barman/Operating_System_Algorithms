using System;
using System.Collections.Generic;


namespace CycleDetection
{
    public class Program
    {
        static void Main(String[] args)
        {


            var nodes = new List<TrackingNodes>()
            {
                new TrackingNodes(){Name = "D", Flag = 1},
                new TrackingNodes(){Name = "T", Flag = 1},
                new TrackingNodes(){Name = "E", Flag = 1},
                new TrackingNodes(){Name = "V", Flag = 1},
                new TrackingNodes(){Name = "G", Flag = 1},
                new TrackingNodes(){Name = "U", Flag = 1},
            };


            var edges_list = new List<String>()
            {
                "T","E","V","G","U","D"
            };

            var tracking_nodes = new List<TrackingNodes>()
            {
                new TrackingNodes(){Name = "D", S_Index = 0 , E_Index = 0},
                new TrackingNodes(){Name = "T", S_Index = 1 , E_Index = 1},
                new TrackingNodes(){Name = "E", S_Index = 2 , E_Index = 2},
                new TrackingNodes(){Name = "V", S_Index = 3 , E_Index = 3},
                new TrackingNodes(){Name = "G", S_Index = 4 , E_Index = 4},
                new TrackingNodes(){Name = "U", S_Index = 5 , E_Index = 5}
            };




            /*
            var nodes = new List<TrackingNodes>()
            {
                new TrackingNodes(){Name = "R", Flag = 1},
                new TrackingNodes(){Name = "A", Flag = 1},
                new TrackingNodes(){Name = "S", Flag = 1},
                new TrackingNodes(){Name = "D", Flag = 1},
                new TrackingNodes(){Name = "T", Flag = 1},
            };


            var edges_list = new List<String>()
            {
                "A","S","NULL","S","T","NULL"
            };

            var tracking_nodes = new List<TrackingNodes>()
            {
                new TrackingNodes(){Name = "R", S_Index = 0 , E_Index = 0},
                new TrackingNodes(){Name = "A", S_Index = 1 , E_Index = 1},
                new TrackingNodes(){Name = "S", S_Index = 2 , E_Index = 2},
                new TrackingNodes(){Name = "D", S_Index = 3 , E_Index = 4},
                new TrackingNodes(){Name = "T", S_Index = 5 , E_Index = 5},
            };

            */


            // var nodes = new List<TrackingNodes>();

            // var edges_list = new List<String>();

            // var tracking_nodes = new List<TrackingNodes>();

            // var proceses = new List<string>();

            // var resources = new List<string>();


            // Code for the user input starts from here.............


            // Console.Write("Number of Nodes: ");
            // var node_num = Convert.ToInt32(Console.ReadLine());

            // Console.WriteLine("Node Names : ( Input values whether its a process(p) or resource(r) )  ");

            // for (int i = 1; i <= node_num; i++)
            // {
            //     var n = Console.ReadLine();
            //     nodes.Add(new TrackingNodes() { Name = n, Flag = 1 });
            //     var p_r = Console.ReadLine();
            //     if (p_r == "p")
            //     {
            //         proceses.Add(n);
            //     }
            //     else
            //     {
            //         resources.Add(n);
            //     }
            // }



            // Console.WriteLine("\nEdges: ");


            // for (int i = 0; i < nodes.Count; i++)
            // {
            //     int starting_index;
            //     int end_index;
            //     Console.WriteLine($"Enter edge number for {nodes[i].Name} :");
            //     var p_node_num = Convert.ToInt32(Console.ReadLine());
            //     starting_index = edges_list.Count;
            //     if (p_node_num == 0)
            //     {
            //         edges_list.Add("NULL");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Now enter edges: ");
            //         for (int j = 1; j <= p_node_num; j++)
            //         {
            //             edges_list.Add(Console.ReadLine());
            //         }
            //     }
            //     end_index = edges_list.Count - 1;

            //     tracking_nodes.Add(new TrackingNodes() { Name = nodes[i].Name, S_Index = starting_index, E_Index = end_index });
            // }




            foreach (var tracking in tracking_nodes)
            {
                Console.WriteLine($"{tracking.Name} : {tracking.S_Index}    ,    {tracking.E_Index}");
                for (int n = tracking.S_Index; n <= tracking.E_Index; n++)
                {
                    Console.WriteLine($"{edges_list[n]}     ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Entered edges: ");

            foreach (String edge in edges_list)
            {
                Console.Write($"{edge}      ");
            }

            Console.WriteLine();

            var Deadlock = new List<String>();

            int x = 0;

            // The first element of nodes list is inserted into Deadlock list. 

            Deadlock.Add(nodes[x].Name);
            showList(Deadlock);
            Console.WriteLine();

            // The starting index for the first node   
            int p = tracking_nodes[x].S_Index;

            String addingnode = edges_list[p];
            Console.Write($"\n{addingnode}");
            DetectCycle(Deadlock, addingnode, nodes);
            Deadlock.Add(edges_list[p]);
            showList(Deadlock);
            Console.WriteLine();


            int node_index = ReturnNodeIndex(nodes, Deadlock[Deadlock.Count - 1]);

            //Console.WriteLine($"\n{Deadlock[Deadlock.Count - 1]}        {node_index}");


            Addnodes(nodes, tracking_nodes, edges_list, Deadlock, node_index);

            void Addnodes(List<TrackingNodes> nodes, List<TrackingNodes> trackingNodes, List<String> edges_list, List<String> Deadlock, int node_index)
            {
                addingnode = edges_list[tracking_nodes[node_index].S_Index];

                Console.Write($"\n{addingnode}");

                if (addingnode != "NULL")
                {
                    if (ReturnNodeFlag(nodes, addingnode) == 1)
                    {
                        DetectCycle(Deadlock, addingnode, nodes);

                        if (Deadlock.Count != 0)
                        {
                            Deadlock.Add(addingnode);
                            showList(Deadlock);
                            Console.WriteLine();
                            node_index = ReturnNodeIndex(nodes, Deadlock[Deadlock.Count - 1]);
                            Addnodes(nodes, trackingNodes, edges_list, Deadlock, node_index);
                        }
                    }
                }
                else
                {
                    Makenodevisited(nodes, Deadlock[Deadlock.Count - 1]);
                    RemoveNode(Deadlock);
                    BackTrack(Deadlock, Deadlock[Deadlock.Count - 1], trackingNodes, nodes);
                }
            }


            // This will return nodeindex from the nodes list......
            int ReturnNodeIndex(List<TrackingNodes> nodes, String node)
            {
                int n = 0;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (node.Equals(nodes[i].Name))
                    {
                        n = i;
                    }
                }
                return n;
            }


            // This will return the flagvalue of the particular node from the nodes list......
            int ReturnNodeFlag(List<TrackingNodes> nodes, String node)
            {
                int n = ReturnNodeIndex(nodes, node);
                return nodes[n].Flag;
            }


            // This will set the flagvalue of a particular node to 0 & return the value it means the flag is visited.........
            int Makenodevisited(List<TrackingNodes> nodes, String node)
            {
                int n = ReturnNodeIndex(nodes, node);
                nodes[n].Flag = 0;
                return nodes[n].Flag;
            }


            // This will detect cycle........ 
            void DetectCycle(List<String> Deadlock, String Dead, List<TrackingNodes> nodes)
            {
                for (int m = 0; m < Deadlock.Count; m++)
                {
                    if (Dead == Deadlock[m])
                    {
                        Console.WriteLine("\nDeadlock detected...............");
                        ShowDetectedCycle(Deadlock, Dead, nodes);
                    }
                    else
                    {
                        if (m == Deadlock.Count - 1)
                            Console.WriteLine("\nNo Deadlock detected...............");
                    }
                }
            }


            // This will show the nodes in the detected cycle.........
            void ShowDetectedCycle(List<String> Dealock, String Dead, List<TrackingNodes> nodes)
            {
                foreach (String s in Deadlock)
                {
                    Console.Write($"{s}     ");
                    int sn = Makenodevisited(nodes, s);
                    // Console.Write($"{sn}    ");
                }
                Console.Write($"{Dead}");
                Dealock.Clear();
            }


            // This will show the deadlock list.....
            void showList(List<String> Deadlock)
            {
                Console.WriteLine("Deadlock list: ");
                foreach (String s in Deadlock)
                {
                    Console.Write($"{s}   ");
                }
            }


            // This will remove the last node from the list..........
            void RemoveNode(List<String> Deadlock)
            {
                Deadlock.RemoveAt(Deadlock.Count - 1);
            }


            // 
            void BackTrack(List<String> Deadlock, String ParentNode, List<TrackingNodes> trackingNodes, List<TrackingNodes> nodes)
            {
                int parent_node_index = ReturnNodeIndex(nodes, ParentNode);

                if (trackingNodes[parent_node_index].S_Index == trackingNodes[parent_node_index].E_Index)
                {
                    Makenodevisited(nodes, Deadlock[Deadlock.Count - 1]);
                    RemoveNode(Deadlock);
                    BackTrack(Deadlock, Deadlock[Deadlock.Count - 1], trackingNodes, nodes);
                }
                else
                {
                    int current_child_index = trackingNodes[parent_node_index].S_Index;

                    while (current_child_index <= trackingNodes[parent_node_index].E_Index)
                    {
                        current_child_index++;
                        Addnodes(nodes, trackingNodes, edges_list, Deadlock, current_child_index);
                    }
                }
            }
        }


        public class TrackingNodes
        {
            public String Name { get; set; }

            public int S_Index { get; set; }

            public int E_Index { get; set; }

            public int Flag { get; set; }

        }
    }

}