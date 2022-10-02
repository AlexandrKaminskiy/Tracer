using System;
using System.Collections.Generic;
using System.Text;
using TracerLibrary;
namespace ActivityWorkers
{
    public class Filtering
    {
        ITracer tracer;
        public Filtering(ITracer tracer)
        {
            this.tracer = tracer;
        }
        public int[] Filter(int[] mas)
        {
            tracer.StartTrace();
            FindMax(mas);
            FindMin(mas); 
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 0)
                {
                    mas[i] = 0;
                }
            }
            tracer.StopTrace();
            return mas;
        }

        void FindMax(int[] mas)
        {
            tracer.StartTrace();
            int max = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > max)
                {
                    max = mas[i];
                }
            }
            Console.WriteLine(max);
            tracer.StopTrace();
        }

        void FindMin(int[] mas)
        {
            tracer.StartTrace();
            int min = mas[0];
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < min)
                {
                    min = mas[i];
                }
            }
            Console.WriteLine(min);
            tracer.StopTrace();
        }
    }
}
