using System;
using System.Collections.Generic;
using _02_Claims;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimRepositoryTest
{
    [TestClass]
    public class ClaimRepositoryTest
    {
        [TestMethod]
        public void AddClaimToClaimsQueue_ShouldGetCorrectBoolean()
        {
            Claim claim = new Claim();
            ClaimRepository repository = new ClaimRepository();

            bool addResult = repository.AddClaimToClaimsQueue(claim);

            Assert.IsTrue(addResult);
            Console.WriteLine(addResult);
        }

        [TestMethod]
        public void GetClaim_ShouldReturnCorrectMenuItemList()
        {
            Claim claim = new Claim();
            ClaimRepository repo = new ClaimRepository();

            repo.AddClaimToClaimsQueue(claim);
            Queue<Claim> claims = repo.GetClaimsQueue();

            bool queueHasClaim = claims.Contains(claim);
            Assert.IsTrue(queueHasClaim);
            Console.WriteLine(queueHasClaim);
        }
        private ClaimRepository _repo;
        private Claim _claim;
        [TestInitialize]

        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim("1", ClaimType.Car, "Car accident on 465", 400.00m, Convert.ToDateTime("4 / 25 / 2018"), Convert.ToDateTime("4 / 27 / 2018"));
            _repo.AddClaimToClaimsQueue(_claim);
        }


        [TestMethod]
        public void DequeueClaim_ShouldReturnCorrectBool()
        {
            _repo = new ClaimRepository();
            _claim = new Claim("1", ClaimType.Car, "Car accident on 465", 400.00m, Convert.ToDateTime("4 / 25 / 2018"), Convert.ToDateTime("4 / 27 / 2018"));
            _repo.AddClaimToClaimsQueue(_claim);

            Queue<Claim> testQueue = _repo.GetClaimsQueue();
            Assert.IsTrue(testQueue.Count == 1);

            _repo.DequeueExistingClaim();
            testQueue = _repo.GetClaimsQueue();
            Assert.AreEqual(0, testQueue.Count);
        }
    }
}

