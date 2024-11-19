using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Involved.HTF.Common.Dto
{
    public enum Level
    {
        Easy,
        Medium,
        Hard,
        Bonus
    }
    public class Challenge
    {
        int challengeId;
        string name;
        int diameter;
        int x;
        int y;
        Level level;
        string challengeType;
    }
}
