using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Color(IEgg egg, IBunny bunny)
        {
            foreach (var item in bunny.Dyes)
            {
                while (!item.IsFinished())
                {
                  bunny.Work();
                    egg.GetColored();
                    item.Use();
                    if (egg.IsDone() || bunny.Energy == 0)
                    {
                        return;
                    }
                }
            }
        }
    }
}
