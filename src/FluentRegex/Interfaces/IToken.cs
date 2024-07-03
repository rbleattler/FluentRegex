using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using FluentRegex.Exceptions;
[assembly: InternalsVisibleTo("FluentRegex.Tests")]
namespace FluentRegex;


/// <summary>
/// Interface <c>IBuilder</c> defines the methods and properties for building a regular expression pattern.
/// </summary>
public interface IToken
{
    /// <summary>
    /// Gets the literal value of the regex token with the specified name.
    /// </summary>
    public string GetToken(string tokenName)
    {
        // If there is a public static property with the name of the token, return the value of that property
        var token = typeof(IToken).GetProperty(tokenName);
        if (token != null)
        {
            return token.GetValue(null)!
                         .ToString()!;
        }
        else
        {
            return string.Empty;
        }
    }

}