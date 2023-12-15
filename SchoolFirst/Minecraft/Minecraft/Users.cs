using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
  
    internal class Users
    {
        Werkzeuge tools = new Werkzeuge();

        private int _maxEXP;
        private int _currentEXP;
        private int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public int CurrentEXP
        {
            get { return _currentEXP; }
            set { _currentEXP = value; }
        }

        public int MaxEXP
        {
            get { return _maxEXP; }
            set { _maxEXP = value; }
        }

        public Users() 
        {
            _maxEXP= 10;
            _currentEXP= 0;
            _level = 1;
        }

   

        public bool CheckForLvlUP()
        {

            if (_currentEXP >= _maxEXP) 
            {
                int buffer = _currentEXP -= _maxEXP;
                _maxEXP= _maxEXP*2;
                _currentEXP= buffer;
                return true;
              
            }
            return false;
          
        }

    }
}
