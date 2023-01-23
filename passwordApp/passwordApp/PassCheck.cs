using System;
using System.Linq;

namespace passwordApp
{
    internal class PassCheck
    {
        private string pass;
        private string specialChar;
        private int minLen;

        public string Pass { 
            get { return pass; } 
            set { pass = value; } 
        }

        public int MinimumLen { 
            get { return minLen; } 
            set { minLen = value; } 
        }

        public PassCheck()
        {
            minLen = 8;
            specialChar = "!@#$%^&*()_-=[]{}|><+";
            pass = String.Empty;
        }
        
        public string SpecialCHar { 
            get { return specialChar; } 
            set { specialChar = value; } 
        }

        public bool HasRightLenght()
        {
            return this.pass.Length >= this.minLen;
        }

        public bool HasSpecialChar()
        {
            return this.pass.Any(a => specialChar.Contains(a));
        }

        public bool HasNumber()
        {
            return this.pass.Any(char.IsDigit);
        }

        public bool HasUpperLetter()
        {
            return this.pass.Any(char.IsUpper);
        }

        public bool IsStrong() {
            return this.HasNumber() && this.HasSpecialChar() && this.HasUpperLetter() && this.HasRightLenght();
        }
  
        
    }
}
