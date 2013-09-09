NDateTimePicker
===============

This is a simple nullable DateTime picker user control based on the standard user control available in Windows Forms.
It works with .NET framework 1.1 and above.

NDateTimePicker simply inherits from System.Windows.Forms.DateTimePicker enablgind the ShowCheckBox property and shadowing the default property Value allowing null values (null/Nothing ans DBNull).

It also exposes some useful properties such as: IsNull/IsNotNull (to check if the value is null before trying to read it) and ValueAsNullable (which allows direct access to the Value property casted to a Nullable(Of DateTime)/Nullable?).

Have fun with it.
