using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace
MacroGuards.Tests
{


[TestClass]
public class
GuardTests
{


[TestMethod]
public void
NotNull_NonNull_Value_Succeeds()
{
    Guard.NotNull(new object(), "paramName");
}


[TestMethod]
public void
NotNull_Passes_Through_Value()
{
    var obj = new object();
    Assert.AreEqual(
        Guard.NotNull(obj, "paramName"),
        obj);
}


[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void
NotNull_Null_Value_Throws_ArgumentNullException()
{
    Guard.NotNull((object)null, "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void
NotNull_Null_ParamName_Throws_ArgumentNullException()
{
    Guard.NotNull(new object(), null);
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
NotNull_Empty_ParamName_Throws_ArgumentException()
{
    Guard.NotNull(new object(), "");
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
NotNull_WhiteSpace_ParamName_Throws_ArgumentException()
{
    Guard.NotNull(new object(), " ");
}


[TestMethod]
public void
Required_Valid_Value_Succeeds()
{
    Guard.Required("abc", "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void
Required_Null_Value_Throws_ArgumentNullException()
{
    Guard.Required(null, "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
Required_Empty_Value_Throws_ArgumentException()
{
    Guard.Required("", "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
Required_WhiteSpace_Value_Throws_ArgumentException()
{
    Guard.Required(" ", "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void
Required_Null_ParamName_Throws_ArgumentNullException()
{
    Guard.Required("abc", null);
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
Required_Empty_ParamName_Throws_ArgumentException()
{
    Guard.Required("abc", "");
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
Required_WhiteSpace_ParamName_Throws_ArgumentException()
{
    Guard.Required("abc", " ");
}


[TestMethod]
public void
NotEmpty_NonEmpty_Value_Succeeds()
{
    Guard.NotEmpty("abc", "paramName");
}


[TestMethod]
public void
NotEmpty_Null_Value_Succeeds()
{
    Guard.NotEmpty(null, "paramName");
}


[TestMethod]
public void
NotEmpty_WhiteSpace_Value_Succeeds()
{
    Guard.NotEmpty(" ", "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
NotEmpty_Empty_Value_Throws_ArgumentException()
{
    Guard.NotEmpty("", "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void
NotEmpty_Null_ParamName_Throws_ArgumentNullException()
{
    Guard.NotEmpty("abc", null);
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
NotEmpty_Empty_ParamName_Throws_ArgumentException()
{
    Guard.NotEmpty("abc", "");
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
NotEmpty_WhiteSpace_ParamName_Throws_ArgumentException()
{
    Guard.NotEmpty("abc", " ");
}


[TestMethod]
public void
NotWhiteSpaceOnly_Null_Value_Succeeds()
{
    Guard.NotWhiteSpaceOnly(null, "paramName");
}


[TestMethod]
public void
NotWhiteSpaceOnly_Empty_Value_Succeeds()
{
    Guard.NotWhiteSpaceOnly("", "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
NotWhiteSpaceOnly_WhiteSpace_Value_Throws_ArgumentException()
{
    Guard.NotWhiteSpaceOnly(" ", "paramName");
}


[TestMethod]
[ExpectedException(typeof(ArgumentNullException))]
public void
NotWhiteSpaceOnly_Null_ParamName_Throws_ArgumentNullException()
{
    Guard.NotWhiteSpaceOnly("abc", null);
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
NotWhiteSpaceOnly_Empty_ParamName_Throws_ArgumentException()
{
    Guard.NotWhiteSpaceOnly("abc", "");
}


[TestMethod]
[ExpectedException(typeof(ArgumentException))]
public void
NotWhiteSpaceOnly_WhiteSpace_ParamName_Throws_ArgumentException()
{
    Guard.NotWhiteSpaceOnly("abc", " ");
}


}
}
