using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Claims_Repository
{
    public class ClaimMenuRepo
    {
        private Queue<ClaimMenu> _queueOfClaims = new Queue<ClaimMenu>(); 

        //Create
        public bool AddNewClaim(ClaimMenu newClaim)
        {
            int initCount = _queueOfClaims.Count;
            _queueOfClaims.Enqueue(newClaim);
            if(initCount < _queueOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Read
        public Queue<ClaimMenu> GetClaimsList()
        {
            return _queueOfClaims;
        }

        //Update - Update and Delete seem to be the same process which is to remove from Queue but delete makes more sense in this program
        

        //Delete (remove from Queue)
        public bool RemoveFromQueue()
        {
            int initCount = _queueOfClaims.Count;
            _queueOfClaims.Dequeue();
            if (initCount > _queueOfClaims.Count)
            {
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
    }
}
