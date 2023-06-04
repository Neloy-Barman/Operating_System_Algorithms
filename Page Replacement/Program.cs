using System;
using System.Collections.Generic;
using System.Linq;

namespace PageReplacement
{
    public class Program
    {
        static void Main(String[] args)
        {
            Console.Write("Number of pages: ");

            var nu_of_pages = Convert.ToInt32(Console.ReadLine());

            Console.Write("Number of page References: ");

            var nu_of_page_ref = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Reference String: ");

            var Ref_Strings = new List<int>();

            for (int i = 0; i < nu_of_page_ref; i++)
            {
                Ref_Strings.Add(Convert.ToInt32(Console.ReadLine()));
            }

            Console.Write("Number of Memory Page Frame: ");

            var nu_of_me_page_fr = Convert.ToInt32(Console.ReadLine());


            int[] Page_Array = new int[nu_of_me_page_fr];

            for (int k = 0; k < nu_of_me_page_fr; k++)
            {
                Page_Array[k] = 999;
            }




            // Code for FIFO Page replacement starts here.............

            /*
            var page_fault = 0;
            var insert_index = 0;
            int j = 0;
            Page_Array[0] = Ref_Strings.ElementAt(0);
            page_fault++;
            showArray(Page_Array[0], page_fault,Page_Array);
            j++;
            insert_index++;
            FIFOPageReplacement(j,insert_index,page_fault,nu_of_me_page_fr,Ref_Strings,Page_Array);
            void FIFOPageReplacement(int i, int insert_index, int page_fault, int nu_of_page_fr, List<int> Ref_Strings, int[] Page_Array)
            {
                int flag = 0;
                var temp = Ref_Strings.ElementAt(i);
                for (int j = 0; j < Page_Array.Length; j++)
                {
                    if (Page_Array[j] == temp)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    page_fault++;
                    Page_Array[insert_index] = temp;
                    flag = 0;
                    insert_index++;
                    if (insert_index == nu_of_page_fr)
                    {
                        insert_index = 0;
                    }
                    FIFORecursive_Call(i, temp, insert_index, page_fault, nu_of_page_fr, Ref_Strings, Page_Array);
                }
                else
                {
                    FIFORecursive_Call(i, temp,insert_index, page_fault, nu_of_page_fr, Ref_Strings, Page_Array);
                }
            }
            void FIFORecursive_Call(int i, int temp,int insert_index, int page_fault, int nu_of_page_fr, List<int> Ref_Strings, int[] Page_Array)
            {
                showArray(temp, page_fault, Page_Array);
                i++;
                if (i == Ref_Strings.Count)
                {
                    Environment.Exit(0);
                }
                FIFOPageReplacement(i, insert_index, page_fault, nu_of_page_fr, Ref_Strings, Page_Array);
            }

            */

            // Code for the FIFO page replacement ends here.............






            // Code for Optimal Page replacement starts here...........



            var page_fault = 0;

            var j = 0;

            for (int i = 0; i < nu_of_me_page_fr; i++)
            {
                Page_Array[i] = Ref_Strings.ElementAt(i);
                page_fault++;
                showArray(Page_Array[i], page_fault, Page_Array);
            }

            j = nu_of_me_page_fr;

            OptimalPageReplacement(j, page_fault, nu_of_me_page_fr, Ref_Strings, Page_Array);

            void OptimalPageReplacement(int i, int page_fault, int nu_of_me_page_fr, List<int> Ref_Strings, int[] Page_Array)
            {
                int flag = 0;
                int insert_index = 0;
                var temp = Ref_Strings.ElementAt(i);

                for (int j = 0; j < Page_Array.Length; j++)
                {
                    if (Page_Array[j] == temp)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    page_fault++;

                    int[,] IndexInRef = new int[nu_of_me_page_fr, 2];
                    int[] secondarray = new int[nu_of_me_page_fr];

                    for (int k = 0; k < nu_of_me_page_fr; k++)
                    {
                        IndexInRef[k, 1] = 0;
                    }
                    for (int k = 0; k < Page_Array.Length; k++)
                    {
                        for (int l = i + 1; l < Ref_Strings.Count; l++)
                        {
                            if (Ref_Strings.ElementAt(l) == Page_Array[k] && IndexInRef[k, 1] != 1)
                            {
                                IndexInRef[k, 0] = l;
                                secondarray[k] = l;
                                IndexInRef[k, 1] = 1;
                            }
                            else if (Ref_Strings.ElementAt(l) != Page_Array[k] && IndexInRef[k, 1] != 1)
                            {
                                secondarray[k] = nu_of_me_page_fr++;
                            }

                        }
                    }

                    int max = secondarray.Max();
                    var min = secondarray.Min();

                    for (int l = 0; l < Page_Array.Length; l++)
                    {

                        if (max == secondarray[l])
                        {
                            insert_index = l;
                        }

                    }
                    Page_Array[insert_index] = temp;
                    flag = 0;
                    OptimalRecursive_Call(i, temp, page_fault, nu_of_me_page_fr, Ref_Strings, Page_Array);
                }
                else
                {
                    OptimalRecursive_Call(i, temp, page_fault, nu_of_me_page_fr, Ref_Strings, Page_Array);
                }
            }

            void OptimalRecursive_Call(int i, int temp, int page_fault, int nu_of_page_fr, List<int> Ref_Strings, int[] Page_Array)
            {
                showArray(temp, page_fault, Page_Array);
                i++;
                if (i == Ref_Strings.Count)
                {
                    Environment.Exit(0);
                }
                OptimalPageReplacement(i, page_fault, nu_of_page_fr, Ref_Strings, Page_Array);
            }


            // Code for the optimal page replacement ends here................





            // Code for LCS Page replacement starts from here...............

            /*

            var page_fault = 0;

            var j = 0;

            int[,] IndexInRef = new int[nu_of_me_page_fr, 2];

            var changing_flag = 3;

            for (int i = 0; i < nu_of_me_page_fr; i++)
            {
                Page_Array[i] = Ref_Strings.ElementAt(i);
                IndexInRef[i, 1] = changing_flag;
                changing_flag-- ;
                page_fault++;
                showArray(Page_Array[i], page_fault, Page_Array);
            }

            void shsgfs(int[,] IndexInRef)
            {
                Console.WriteLine();
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{IndexInRef[i, 1]}       ");
                }
                Console.WriteLine();
            }
 
         

            j = nu_of_me_page_fr;

            LCSPageReplacement(j, page_fault, nu_of_me_page_fr, Ref_Strings, Page_Array, IndexInRef);

            void LCSPageReplacement(int i, int page_fault, int nu_of_me_page_fr, List<int> Ref_Strings, int[] Page_Array, int[,] IndexInRef)
            {
                int flag = 0;
                var temp = Ref_Strings.ElementAt(i);
                var stored = 0;

                for (int j = 0; j < Page_Array.Length; j++)
                {
                    if (Page_Array[j] == temp)
                    {
                        flag = 1;
                        IndexInRef[j, 1] = 1;
                        stored = j;
                    }
                }
                if (flag == 0)
                {
                    page_fault++;
                    for(int k = 0; k < nu_of_me_page_fr; k++)
                    {
                        if(IndexInRef[k,1] == 3)
                        {
                            Page_Array[k] = temp;
                        }
                    }
                    //shsgfs(IndexInRef);
                    ShiftingValues1(IndexInRef,nu_of_me_page_fr);
                    //shsgfs(IndexInRef);
                    flag = 0;

                    LCSRecursive_Call(i, temp, page_fault, nu_of_me_page_fr, Ref_Strings, Page_Array, IndexInRef);
                }
                else
                {
                    //shsgfs(IndexInRef);
                    ShiftingValues2(IndexInRef, nu_of_me_page_fr, stored);
                    //shsgfs(IndexInRef);
                    LCSRecursive_Call(i, temp, page_fault, nu_of_me_page_fr, Ref_Strings, Page_Array, IndexInRef);
                }
            }

            void ShiftingValues1(int[,] IndexInRef, int nu_of_me_page_fr)
            {
                for(int k = 0;k < nu_of_me_page_fr; k++)
                {
                    if(IndexInRef[k,1] == 3)
                    {
                        IndexInRef[k, 1] = 1;
                    }
                    else if (IndexInRef[k, 1] == 2)
                    {
                        IndexInRef[k, 1] = 3;
                    }
                    else if (IndexInRef[k, 1] == 1)
                    {
                        IndexInRef[k, 1] = 2;
                    }
                }
            }

            void ShiftingValues2(int[,] IndexInRef, int nu_of_me_page_fr, int stored)
            {
                for (int k = 0; k < nu_of_me_page_fr; k++)
                {
                    if(k == stored)
                    {
                        IndexInRef[k, 1] = 1;
                    }
                    else
                    {
                        if (IndexInRef[k, 1] == 3)
                        {
                            IndexInRef[k, 1] = 3;
                        }
                        else if (IndexInRef[k, 1] == 2)
                        {
                            IndexInRef[k, 1] = 3;
                        }
                        else if (IndexInRef[k, 1] == 1)
                        {
                            IndexInRef[k, 1] = 2;
                        }
                    }
                }
            }

            void LCSRecursive_Call(int i, int temp, int page_fault, int nu_of_page_fr, List<int> Ref_Strings, int[] Page_Array, int[,] IndexInRef)
            {
                showArray(temp, page_fault, Page_Array);
                i++;
                if (i == Ref_Strings.Count)
                {
                    Environment.Exit(0);
                }
                LCSPageReplacement(i, page_fault, nu_of_page_fr, Ref_Strings, Page_Array, IndexInRef);
            }
            */

            // Code for the LCS page replacement ends here................


            void showArray(int temp, int page_fault, int[] mem_frame)
            {
                Console.Write($"For {temp}  : ");
                foreach (int s in mem_frame)
                {
                    Console.Write($"{s}     ");
                }
                Console.WriteLine();
                Console.WriteLine($"Page fault: {page_fault}");
                Console.WriteLine();
            }

            void show2DArray(int nu_of_me_page_fr, int[,] mem_frame)
            {
                for (int i = 0; i < nu_of_me_page_fr; i++)
                {
                    Console.Write($"{mem_frame[i, 0]}    ");
                }
                Console.WriteLine();
            }
        }
    }
}