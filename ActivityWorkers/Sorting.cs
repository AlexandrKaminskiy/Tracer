using System;
using System.Collections.Generic;
using System.Text;
using TracerLibrary;

namespace ActivityWorkers
{
    public class Sorting
    {
        private ITracer tracer;
        private Filtering filtering;
        public Sorting(ITracer tracer)
        {
            this.tracer = tracer;
            filtering = new Filtering(tracer);
        }

        public int[] SortAndFilter(int[] mas)
        {
            tracer.StartTrace();
            filtering.Filter(mas);
            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                Swap(mas, min, i);
            }
            tracer.StopTrace();
            return mas;
        }

        void Swap(int[] mas, int min, int i) 
        {
            tracer.StartTrace();
            int temp = mas[min];
            mas[min] = mas[i];
            mas[i] = temp;
            tracer.StopTrace();
        }
        
    }
}
