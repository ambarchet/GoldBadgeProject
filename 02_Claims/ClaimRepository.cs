using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimRepository
    {
        private readonly Queue<Claim> _claimsQueue = new Queue<Claim>();

        public Queue<Claim> GetClaimsQueue()
        {
            return _claimsQueue;
        }

        public Claim GetClaimFromQueue()
        {
            return _claimsQueue.Peek();
        }
        //public Claim GetClaimByClaimID(string claimID)
        //{ 
        //    foreach (Claim claim in _claimsQueue)
        //    {
        //        if(claim.ClaimID.ToLower() == claimID.ToLower())
        //        {
        //        return claim;
        //        }
        //    }
        //    return null;
        //}
        public bool AddClaimToClaimsQueue(Claim claim)
        {
            int claimsQueueLength = _claimsQueue.Count();
            _claimsQueue.Enqueue(claim);
            bool wasAdded = claimsQueueLength + 1 == _claimsQueue.Count();
            return wasAdded;
        }
        public void DequeueExistingClaim()
        {
            _claimsQueue.Dequeue();
        }

    }
}
