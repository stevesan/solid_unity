
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Text.RegularExpressions;

public class UtilTest
{
    [Test]
    public void TestTwo() {
        Assert.AreEqual(2, Util.ReturnTwo());
    }
}
