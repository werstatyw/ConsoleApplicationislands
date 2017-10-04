using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            int[] arr;
            int maxi;
            Console.WriteLine("Task 1: generate heights (0=sea 0<land)");
            arr=genarray(n);
            print(arr);
            Console.WriteLine("Task 2: maximum index and maximum height");
            maxi = firstmax(arr);
            Console.WriteLine(maxi + " " + arr[maxi]);
            Console.WriteLine("Task 3: how many times does maximum occur");
            Console.WriteLine(numofmax(arr, maxi));
            Console.WriteLine("Task 4: Longest and index");
            longestisland(arr);
            Console.Read();
        }
        static int[] genarray(int n)//random generation of heights
        {
            int[] a = new int[n];
            Random r = new Random();
            for(int i=0;i<a.Length;i++)
            {
                int v = r.Next(0, 100);
                if (v < 40) a[i] = r.Next(1, 11);//land
                else a[i] = 0;//sea
            }
            return a;
        }
        static void print(int[] a)//print array
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
        static int firstmax(int[] a)//finsd the index of first max element
        {
            int max = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > a[max]) max = i;
            }
            return max;
        }
        static int numofmax(int[] a,int mx)//returns the number of occurance of maximum
        {
            int nummx=0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == a[mx]) nummx++;
            }

        return nummx;
        }
        static void longestisland(int[] a)
        {
            int curindx = 0;
            int indx = 0;
            int curmax = 0;
            int maxmax = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i]>0)
                {
                    curmax += 1;
                    if(curmax==1)
                    {
                        Console.WriteLine("New island at:"+i);
                        curindx = i;
                    }
                }
                if(a[i]==0)
                {
                    Console.WriteLine("New water at:"+i);
                    if(curmax>maxmax)
                    {
                        Console.WriteLine("New max at:"+curindx);
                        maxmax = curmax;
                        indx = curindx; 
                    }
                    curmax = 0;
                    curindx = 0;
                }
            }
            if (curmax > maxmax)
            {
                maxmax = curmax;
                indx = curindx;
            }
            Console.WriteLine("index: " + indx + " Length: " + maxmax);
        }
    }
}
