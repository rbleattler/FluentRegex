using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Builder;


class State
{
    public State()
    {
        Options = new RegexOptions();
        Reset();
    }

    public bool Some { get; set; }
    public bool ZeroOrOne { get; set; }
    public int MinimumOf { get; set; }
    public int MaximumOf { get; set; }
    public RegexOptions Options { get; set; }
    public bool Or { get; set; }
    public bool MultiLine { get; set; }

    // public void SetSome(bool value)
    // {
    //     Some = value;
    //     if (value) Reset();
    // }

    // public void SetZeroOrOne(bool value)
    // {
    //     ZeroOrOne = value;
    //     if (value) Reset();
    // }

    // public void SetMinimumOf(int value)
    // {
    //     MinimumOf = value;
    //     if (value != -1) Reset();
    // }

    // public void SetMaximumOf(int value)
    // {
    //     MaximumOf = value;
    //     if (value != -1) Reset();
    // }

    private void Reset()
    {
        Some = false;
        ZeroOrOne = false;
        MinimumOf = -1;
        MaximumOf = -1;
    }
}