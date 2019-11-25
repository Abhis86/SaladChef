using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaladChef
{
    public class Salad
    {
        private List<Vegetable> mSalad = new List<Vegetable>();
        
        public void AddVegetable(Vegetable vegetable)
        {
            mSalad.Add(vegetable);
        }

        public void Clear()
        {
            mSalad.Clear();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (Vegetable vegetable in mSalad)
                str.Append(vegetable.name + "    ");

            return str.ToString();
        }

        public override bool Equals(object obj)
        {
            Salad other = (obj as Salad);

            if (mSalad.Count == other.mSalad.Count)
            {
                foreach (Vegetable vegetable in mSalad)
                {
                    if (!other.mSalad.Contains(vegetable))
                        return false;
                }
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Salad Copy()
        {
            Salad salad = new Salad();
            foreach (Vegetable vegetable in mSalad)
                salad.AddVegetable(vegetable);
            return salad;
        }
    }
}
