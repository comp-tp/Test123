using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Accela.Apps.Shared.Utils;

namespace Accela.Apps.Shared.Test
{
    [TestFixture]
    public class BizServerVersionTest
    {
        string[] lessVersions = { "6", "6.0", "6.3", "6.3.0", "6.3.1", "6.3.1.1", "6.3.1.9", "6.3.1.10", "6.3.1.99999", "6.3.2.9.0", "6.3.2.9.1", "6.3.2.9.9", "6.3.2.9.10", "6.3.2.9.999999", "6.3.2.9.0_0", "6.3.2.9.0_000000", "6.3.2.9.0_000001", "6.3.2.9.0_900000", "6.3.2.9.0_111111", "6.3.2.9.0_999999" };
        string[] equalVersions1 = { "7", "7.0", "7.0.0", "7.0.0.0", "7.0.0.0.0", "7.0.0.0.0_0", "7.0.0.0.0_000000" };
        string[] equalVersions2 = { "7.3", "7.3.0", "7.3.0.0", "7.3.0.0.0", "7.3.0.0.0_0", "7.3.0.0.0_000000" };
        string[] equalVersions3 = { "7.3", "7.3.0", "7.3.0.0", "7.3.0.0.0", "7.3.0.0.0_0", "7.3.0.0.0_000000" };
        string[] greaterVersions = { "8", "8.0", "8.3", "8.3.0", "8.3.1", "8.3.1.1", "8.3.1.9", "8.3.1.10", "8.3.1.99999", "8.3.2.9.0", "8.3.2.9.1", "8.3.2.9.9", "8.3.2.9.10", "8.3.2.9.999999", "8.3.2.9.0_0", "8.3.2.9.0_000000", "8.3.2.9.0_000001", "8.3.2.9.0_900000", "8.3.2.9.0_111111", "8.3.2.9.0_999999" };

        /// <summary>
        /// all less versions are not equal versions in equalVersions1, equalVersions2, equalVersions3 and greaterVersions.
        /// </summary>
        [Test]
        public void Equal_Return_False()
        {
            bool containEqualVersion = false;

            foreach (var lessVersion in lessVersions)
            {
                var lessVersionInstance = new BizServerVersion(lessVersion);
                var allGreaterVersions = equalVersions1.Concat(equalVersions2).Concat(equalVersions3).Concat(greaterVersions);

                foreach (var greaterVersion in allGreaterVersions)
                {
                    var greaterVersionInstance = new BizServerVersion(greaterVersion);
                    if (lessVersionInstance.Equal(greaterVersionInstance))
                    {
                        containEqualVersion = true;
                        break;
                    }
                }

                if (containEqualVersion)
                {
                    break;
                }
            }

            var result = containEqualVersion == true;

            Assert.IsFalse(result);
        }

        /// <summary>
        /// any one of versions in equalVersions1, equalVersions2, equalVersions3, is equal to any one of other version in same collection.
        /// </summary>
        [Test]
        public void Equal_Return_True()
        {
            bool containNotEqualVersion = false;
            var equalVersionList = new Dictionary<string, string[]>();
            equalVersionList.Add("1", equalVersions1);
            equalVersionList.Add("2", equalVersions2);
            equalVersionList.Add("3", equalVersions3);

            foreach (var item in equalVersionList.Values)
            {
                foreach (var equalVersion in item)
                {
                    var equalVersionInstance = new BizServerVersion(equalVersion);
                    var targetVersions = item.Where(p => !p.Equals(equalVersion)).ToArray();

                    foreach (var targetVersion in targetVersions)
                    {
                        var targetVersionInstance = new BizServerVersion(targetVersion);
                        if (!equalVersionInstance.Equal(targetVersionInstance))
                        {
                            containNotEqualVersion = true;
                            break;
                        }
                    }

                    if (containNotEqualVersion)
                    {
                        break;
                    }
                }

                if (containNotEqualVersion)
                {
                    break;
                }
            }

            var result = containNotEqualVersion == false;

            Assert.IsTrue(result);
        }

        /// <summary>
        /// 1. check any two version in equalVersions1, equalVersions2, equalVersions3 won't Lessthan each other.
        /// 2. check version in greaterVersions are not less than version in equalVersions1, equalVersions2, equalVersions3 and lessVersions
        /// </summary>
        [Test]
        public void LessThan_Return_False()
        {
            bool containLessVersion = false;

            // check any two version in all equal versions are not less than to each other.
            var equalVersionList = new Dictionary<string, string[]>();
            equalVersionList.Add("1", equalVersions1);
            equalVersionList.Add("2", equalVersions2);
            equalVersionList.Add("3", equalVersions3);

            foreach (var item in equalVersionList.Values)
            {
                foreach (var equalVersion in item)
                {
                    var equalVersionInstance = new BizServerVersion(equalVersion);
                    var targetVersions = item.Where(p => !p.Equals(equalVersion)).ToArray();

                    foreach (var targetVersion in targetVersions)
                    {
                        var targetVersionInstance = new BizServerVersion(targetVersion);
                        if (equalVersionInstance.LessThan(targetVersionInstance))
                        {
                            containLessVersion = true;
                            break;
                        }
                    }

                    if (containLessVersion)
                    {
                        break;
                    }
                }

                if (containLessVersion)
                {
                    break;
                }
            }

            var result1 = containLessVersion == true;

            //----------
            // check version in greaterVersions are not less than version in equalVersions1, equalVersions2, equalVersions3 and lessVersions
            foreach (var greaterVersion in greaterVersions)
            {
                var greaterVersionInstance = new BizServerVersion(greaterVersion);
                var allLessVersions = lessVersions.Concat(equalVersions1).Concat(equalVersions2).Concat(equalVersions3);

                foreach (var lessVersion in allLessVersions)    
                {
                    var lessVersionInstance = new BizServerVersion(greaterVersion);
                    if (greaterVersionInstance.LessThan(lessVersionInstance))
                    {
                        containLessVersion = true;
                        break;
                    }
                }

                if (containLessVersion)
                {
                    break;
                }
            }

            var result2 = containLessVersion == true;

            var result = result1 || result2;

            Assert.IsFalse(result);
        }

        [Test]
        public void LessThan_Return_True()
        {
            bool containNotLessVersion = false;

            var allLessVersions = lessVersions.Concat(equalVersions1).Concat(equalVersions2).Concat(equalVersions3);

            foreach (var lessVersion in allLessVersions)
            {
                var lessVersionInstance = new BizServerVersion(lessVersion);
                
                foreach (var greaterVersion in greaterVersions)
                {
                    var greaterVersionInstance = new BizServerVersion(greaterVersion);

                    if (!lessVersionInstance.LessThan(greaterVersionInstance))
                    {
                        containNotLessVersion = true;
                        break;
                    }
                }

                if (containNotLessVersion)
                {
                    break;
                }
            }

            var result = containNotLessVersion == false;

            Assert.IsTrue(result);
        }


        [Test]
        public void LessThanOrEqual_Return_True()
        {
            bool containException = false;

            var allLessVersions = lessVersions.Concat(equalVersions1).Concat(equalVersions2).Concat(equalVersions3);

            foreach (var lessVersion in allLessVersions)
            {
                var lessVersionInstance = new BizServerVersion(lessVersion);

                foreach (var greaterVersion in greaterVersions)
                {
                    var greaterVersionInstance = new BizServerVersion(greaterVersion);

                    if (!lessVersionInstance.LessThanOrEqual(greaterVersionInstance))
                    {
                        containException = true;
                        break;
                    }
                }

                if (containException)
                {
                    break;
                }
            }

            var result = containException == false;

            Assert.IsTrue(result);
        }

        [Test]
        public void GreaterThan_Return_True()
        {
            bool containException = false;

            var allLessVersions = lessVersions.Concat(equalVersions1).Concat(equalVersions2).Concat(equalVersions3);

            foreach (var lessVersion in allLessVersions)
            {
                var lessVersionInstance = new BizServerVersion(lessVersion);

                foreach (var greaterVersion in greaterVersions)
                {
                    var greaterVersionInstance = new BizServerVersion(greaterVersion);

                    if (lessVersionInstance.GreaterThan(greaterVersionInstance))
                    {
                        containException = true;
                        break;
                    }
                }

                if (containException)
                {
                    break;
                }
            }

            Assert.IsTrue(containException==false);
        }

        [Test]
        public void GreaterThanOrEqual_Return_True()
        {
            bool containException = false;

            var allLessVersions = lessVersions.Concat(equalVersions1).Concat(equalVersions2).Concat(equalVersions3);

            foreach (var lessVersion in allLessVersions)
            {
                var lessVersionInstance = new BizServerVersion(lessVersion);

                foreach (var greaterVersion in greaterVersions)
                {
                    var greaterVersionInstance = new BizServerVersion(greaterVersion);

                    if (!greaterVersionInstance.GreaterThan(lessVersionInstance))
                    {
                        containException = true;
                        break;
                    }
                }

                if (containException)
                {
                    break;
                }
            }

            Assert.IsTrue(containException == false);
        }
    }
}
