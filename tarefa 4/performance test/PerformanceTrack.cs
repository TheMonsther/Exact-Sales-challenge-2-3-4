using System.Diagnostics;


namespace performance_test
{
    internal class PerformanceTrack
    {
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            TimeSpan average = TimeSpan.Zero;
            IList<TimeSpan> finals = new List<TimeSpan>();

            for (int j = 2; j <= 4; j++)
            {
                average = TimeSpan.Zero;
                for (int i = 0; i < 11; i++)
                {
                    sw.Start();

                    ProcessarLote(Math.Pow(10, j));

                    sw.Stop();

                    if (i != 0)
                    {
                        average += sw.Elapsed;
                        Console.WriteLine("Run {0} -> Try {1} -> Elapsed={2}", j-1, i, sw.Elapsed);
                    }
                    sw.Restart();
                }
                Console.WriteLine("\n\n");

                finals.Add(TimeSpan.FromMicroseconds(average.TotalMicroseconds/10));
            }

            Console.WriteLine("\n\nResults\n\n");
            int t = 1;
            foreach(TimeSpan finalVal in finals) 
            {
                Console.WriteLine("Run {0} -> Elapsed={1}", t, finalVal);
                t++;
            }

            Console.WriteLine("\n\nMetrics: Max Complexity aceptable O(N)\n\n");
            t = 1;
            TimeSpan baseMetric = finals[0];

            foreach (TimeSpan finalVal in finals)
            {
                if(finalVal <= TimeSpan.FromMicroseconds(baseMetric.TotalMicroseconds*t)) Console.WriteLine("Run {0} -> Elapsed={1}\tMax Expected={2}\t Result: Passed!", t, finalVal, TimeSpan.FromMicroseconds(baseMetric.TotalMicroseconds * t));
                else Console.WriteLine("Run {0} -> Elapsed={1}\tMax Expected={2}\tResult: Failed!", t, finalVal, TimeSpan.FromMicroseconds(baseMetric.TotalMicroseconds * t));
                t++;
            }
            

        }

        public static void ProcessarLote(double size)
        {
            double sum = 0;

            for (double i = 0; i < size; i++)
            {
                for (double j = 0; j < size; j++)
                {
                    sum += (i * j);
                }
            }
        }
    }
}
