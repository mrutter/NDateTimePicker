NDateTimePicker
===============

This is a simple nullable DateTime picker user control based on the standard user control available in Windows Forms.
It works with .NET framework 1.1 and above.

NDateTimePicker simply inherits from System.Windows.Forms.DateTimePicker enabling the ShowCheckBox property and shadowing the default property Value allowing null values (Nothing/null and DBNull.Value).

It also exposes some useful properties such as: IsNull/IsNotNull (to check if the value is null before trying to read it) and ValueAsNullable (which allows direct access to the Value property casted to a Nullable(Of DateTime)/DateTime?).

I also included a project to show the user control usage (see NDateTimePickerTest).

Have fun with it.
