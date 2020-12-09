using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Claims_Repository
{
    public class ClaimMenuRepo
    {
        //private List<ClaimMenu> _listOfClaims = new List<ClaimMenu>();
        private Queue<ClaimMenu> _queueOfClaims = new Queue<ClaimMenu>(); 

        //Create
        public void AddNewClaim(ClaimMenu newClaim)
        {
            _queueOfClaims.Enqueue(newClaim);
        }

        //Read
        public Queue<ClaimMenu> GetClaimsList()
        {
            return _queueOfClaims;
        }

        //Update 


        //Delete (remove from Queue)
        public bool RemoveFromQueue(string claimID)
        {
            if (claimID != null)
            {
                _queueOfClaims.Dequeue();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper method by claimID
        public ClaimMenu GetClaimListByID(string claimID)
        {
            foreach (ClaimMenu claim in _queueOfClaims)
            {
                if(claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }

        //Peek Method
        public ClaimMenu PeekNextClaim()
        {
            return _queueOfClaims.Peek();
        }
    }
}
