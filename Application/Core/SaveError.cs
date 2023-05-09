using System.Collections;

namespace Application.Core
{
    public class SaveError
    {
        private int _statusCode;
        private string _statusText;
        private Hashtable _error;
        public Hashtable Error
        { 
            get
            {
                var hashTable = new Hashtable();
                hashTable.Add("statusCode", _statusCode);
                hashTable.Add("statusText", _statusText);
                return hashTable;
            } 
        }
        public SaveError(string statusText, int statusCode = 400)
        {
            _statusCode = statusCode;
            _statusText = statusText;
        }
    }
}