using System.Collections.Generic;

namespace MathTrainer
{
    public class Settings
    {
        #region Fields and props

        private List<int> _numColl = new List<int>() {0,1,2,3,4,5,6,7,8,9};
        private List<MathOperations> _mathOp = new List<MathOperations>() {MathTrainer.MathOperations.Делить, MathTrainer.MathOperations.Умножать};

        public List<int> Numbers
        {
            get
            {
                return _numColl;                
            }
            set
            {
                _numColl = value;
            }
        }
        public List<MathOperations> MathOperations
        {
            get
            {
                return _mathOp;                
            }
            set
            {
                _mathOp = value;
            }
        }
        #endregion
    }
}
