using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._12._2019_homework_operator_overloading
{
    class ComboItem<T>
    {
        public T Item { get; set; } = default(T);

        public ComboItem(T item)
        {
            Item = item;
        }

        public override string ToString()
        {
            return $"{Item.GetType().GetProperties()[0].Name}: {Item.GetType().GetProperties()[0].GetValue(this.Item).ToString()}"; 
        }
    }
}
