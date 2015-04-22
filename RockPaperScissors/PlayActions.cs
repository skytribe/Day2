using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    // Various Play Actions which utilize inheritance for Property Act
     class PlayAction
    {
        public Acts Act
        {
            get;
            set;
        }
    }
     class PlayerPaper : PlayAction
    {
        public PlayerPaper()
        {
            base.Act = Acts.Paper;
        }
    }

     class PlayerRock : PlayAction
    {
        public PlayerRock()
        {
            base.Act = Acts.Rock;
        }
    }

     class PlayerScissor : PlayAction
    {
        public PlayerScissor()
        {
            base.Act = Acts.Scissor;
        }
    }
}
