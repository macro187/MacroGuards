using System;
using System.Linq;


namespace
MacroGuards
{


/// <summary>
/// Guards for method argument values
/// </summary>
///
public static class
Guard
{


/// <summary>
/// Disallow <c>null</c>, empty, or whitespace-only strings
/// </summary>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="value"/> is <c>null</c>
/// - OR -
/// <paramref name="paramName"/> is <c>null</c>
/// </exception>
///
/// <exception cref="ArgumentException">
/// <paramref name="value"/> is empty or whitespace-only
/// - OR -
/// <paramref name="paramName"/> is empty or whitespace-only
/// </exception>
///
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "param",
    Justification = "Consistency with ArgumentException classes in BCL")]
public static void
Required([ValidatedNotNull] string value, string paramName)
{
    NotNull(value, paramName);
    NotEmpty(value, paramName);
    NotWhiteSpaceOnly(value, paramName);
}


/// <summary>
/// Disallow <c>null</c> values
/// </summary>
///
/// <remarks>
/// Returns the guarded value so can be used to null-guard arguments inline e.g. in constructor chains.
/// </remarks>
///
/// <returns>
/// <paramref name="value"/>
/// </returns>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="value"/> is <c>null</c>
/// - OR -
/// <paramref name="paramName"/> is <c>null</c>
/// </exception>
///
/// <exception cref="ArgumentException">
/// <paramref name="paramName"/> is empty or whitespace-only
/// </exception>
///
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "param",
    Justification = "Consistency with ArgumentException classes in BCL")]
public static T
NotNull<T>([ValidatedNotNull] T value, string paramName)
{
    CheckParamName(paramName);
    if (value == null) throw new ArgumentNullException(paramName);
    return value;
}


/// <summary>
/// Disallow empty strings
/// </summary>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="paramName"/> is <c>null</c>
/// </exception>
///
/// <exception cref="ArgumentException">
/// <paramref name="value"/> is an empty string
/// - OR -
/// <paramref name="paramName"/> is empty or whitespace-only
/// </exception>
///
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "param",
    Justification = "Consistency with ArgumentException classes in BCL")]
public static void
NotEmpty(string value, string paramName)
{
    CheckParamName(paramName);
    if (value == null)
        return;
    if (value.Length == 0)
        throw new ArgumentException(paramName + " is empty", paramName);
}


/// <summary>
/// Disallow strings consisting only of whitespace characters
/// </summary>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="paramName"/> is <c>null</c>
/// </exception>
///
/// <exception cref="ArgumentException">
/// <paramref name="value"/> consists only of whitespace characters
/// - OR -
/// <paramref name="paramName"/> is empty or whitespace-only
/// </exception>
///
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "param",
    Justification = "Consistency with ArgumentException classes in BCL")]
public static void
NotWhiteSpaceOnly(string value, string paramName)
{
    CheckParamName(paramName);
    if (value == null)
        return;
    if (value.Length == 0)
        return;
    if (string.IsNullOrWhiteSpace(value))
        throw new ArgumentException(paramName + " consists only of whitespace", paramName);
}


/// <summary>
/// Disallow strings containing whitespace characters
/// </summary>
///
/// <exception cref="ArgumentNullException">
/// <paramref name="paramName"/> is <c>null</c>
/// </exception>
///
/// <exception cref="ArgumentException">
/// <paramref name="value"/> contains whitespace character(s)
/// - OR -
/// <paramref name="paramName"/> is empty or whitespace-only
/// </exception>
///
[System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "param",
    Justification = "Consistency with ArgumentException classes in BCL")]
public static void
ContainsNoWhiteSpace(string value, string paramName)
{
    CheckParamName(paramName);
    if (value == null)
        return;
    if (value.OfType<char>().Any(c => char.IsWhiteSpace(c)))
        throw new ArgumentException(paramName + " contains whitespace character(s)", paramName);
    var e = Enumerable.Empty<string>();
}


static void
CheckParamName(string paramName)
{
    if (paramName == null)
        throw new ArgumentNullException(nameof(paramName));
    if (paramName.Length == 0)
        throw new ArgumentException("paramName is empty", nameof(paramName));
    if (string.IsNullOrWhiteSpace(paramName))
        throw new ArgumentException("paramName is whitespace-only", nameof(paramName));
}


/// <summary>
/// Indicator to Code Analysis when guard methods protect against <c>null</c>
/// </summary>
///
/// <remarks>
/// See http://stackoverflow.com/questions/15188631/code-analysis-rule-ca1062-behaviour
/// </remarks>
///
sealed class ValidatedNotNullAttribute : Attribute
{
}


}
}
