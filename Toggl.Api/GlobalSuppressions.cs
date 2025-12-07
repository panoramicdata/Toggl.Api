// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
	"Performance", "CA1848:Use the LoggerMessage delegates",
	Justification = "Performance gain does not justify the implementation effort"
)]

[assembly: SuppressMessage(
	"Naming",
	"CA1716:Identifiers should not match keywords",
	Justification = "Type has been marked obsolete.  Will be removed in future versions."
)]
