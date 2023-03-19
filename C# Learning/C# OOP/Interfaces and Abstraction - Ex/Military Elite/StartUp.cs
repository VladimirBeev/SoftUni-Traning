using System;
using System.Collections.Generic;

namespace Military_Elite
{
    public class StartUp
    {
        private static List<Private> privatesId;
        private static LieutenantGeneral lietenants;
        static void Main()
        {
            privatesId = new List<Private>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] action = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (action[0] == "Private")
                {
                    var salary = decimal.Parse(action[4]);
                    Private priva = new Private(action[1],
                        action[2], action[3], salary);
                    privatesId.Add(priva);
                    Console.WriteLine(priva);
                }
                else if (action[0] == "LieutenantGeneral")
                {
                    
                    lietenants = new LieutenantGeneral(action[1],
                        action[2], action[3], decimal.Parse(action[4]), privatesId);
                }
                else if (action[0] == "Engineer")
                {
                    Repairs repair = new Repairs(action[5], int.Parse(action[6]));
                    List<Repairs> repairList = new List<Repairs>();
                    repairList.Add(repair);
                    Engineer lietenants = new Engineer(action[1],
                        action[2], action[3], decimal.Parse(action[4]), action[5],repairList);
                }
                else if (action[0] == "Commando")
                {
                    Missions mission = new Missions(action[5]);
                    List<Missions> missionList = new List<Missions>();
                    missionList.Add(mission);
                    Commando commando = new Commando(action[1], action[2], action[3], decimal.Parse(action[4]), action[5], missionList);
                }
                else if (action[0] == "Spy")
                {
                    Spy spy = new Spy(action[1],
                        action[2], action[3], int.Parse(action[4]));
                }

                command = Console.ReadLine();
            }
        }
    }
}
