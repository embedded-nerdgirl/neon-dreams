// Custom implementation of assertions for release builds
// Avoids debug.assert and works in public

// It also provides some more diagnostic notes for devs -3-

using System;
using System.Runtime.CompilerServices;

public static class Assertion
{
    public static void That(
        bool condition,
        string message = "Assertion failed!",
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        if (!condition)
        {
            string fullMessage = $"{message} (at {filePath}:{lineNumber} in {memberName}())";
            throw new InvalidOperationException(fullMessage);
        }
    }
}
