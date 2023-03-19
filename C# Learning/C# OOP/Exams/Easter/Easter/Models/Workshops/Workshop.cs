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
            foreach (var dye in bunny.Dyes)
            {
                while (!egg.IsDone())
                {
                    if (bunny.Energy > 0)
                    {
                        if (!dye.IsFinished())
                        {
                            bunny.Work();
                            dye.Use();
                            egg.GetColored();
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
            }

            //var isDone = true;
            //while(true)
            //{
            //    foreach (var item in bunny.Dyes)
            //    {
            //        if (bunny.Energy < 0 && bunny.Dyes.Count == 0)
            //        {
            //            isDone = false;
            //            break;
            //        }
            //        if (egg.IsDone())
            //        {
            //            isDone = false;
            //            break;
            //        }
            //        if (item.IsFinished())
            //        {
            //            isDone = false;
            //            break;
            //        }
            //        bunny.Work();
            //        egg.GetColored();
            //    }
            //    if (!isDone)
            //    {
            //        break;
            //    }
            //}

        }
    }
}
