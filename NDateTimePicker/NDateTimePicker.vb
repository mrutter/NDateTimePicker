Imports Microsoft.Win32
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports System.Windows.Forms.Layout

<DefaultEvent("ValueChanged"), ComVisible(True), DefaultProperty("Value"), DefaultBindingProperty("Value"), ClassInterface(ClassInterfaceType.AutoDispatch), Designer("System.Windows.Forms.Design.DateTimePickerDesigner, System.Design")> _
Public Class NDateTimePicker
    Inherits System.Windows.Forms.DateTimePicker

    Private m_pendingChanges As Boolean = False
    Private m_dtconv As DateTimeConverter = New DateTimeConverter()

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    <Browsable(False)> _
    Public ReadOnly Property IsNull As Boolean
        Get
            Return (Me.Value Is Nothing)
        End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IsNotNull As Boolean
        Get
            Return (Me.Value IsNot Nothing)
        End Get
    End Property

    <Browsable(False)> _
    Public Property ValueAsNullable As Nullable(Of DateTime)
        Get
            If IsNull Then
                Return New Nullable(Of DateTime)()
            Else
                Return New Nullable(Of DateTime)(CType(Me.Value, DateTime))
            End If
        End Get
        Set(value As Nullable(Of DateTime))
            If value.HasValue Then
                Me.Value = value.Value
            Else
                Me.Value = Nothing
            End If
        End Set
    End Property

    Public Shadows Property Value As Object
        Get
            If Me.Checked Then
                Return MyBase.Value
            Else
                Return Nothing
            End If
        End Get
        Set(value As Object)
            ' Set a flag to avoid multiple OnValueChanged events
            m_pendingChanges = True

            Try
                Me.SuspendLayout()

                ' Now we check for well-known conditions (null, datetime, convertable, everything else)
                If (value Is Nothing OrElse value Is DBNull.Value) Then
                    Me.Checked = False
                ElseIf TypeOf value Is DateTime Then
                    MyBase.Value = CType(value, DateTime)
                    MyBase.Checked = True
                ElseIf m_dtconv.CanConvertFrom(value.GetType()) Then
                    MyBase.Value = m_dtconv.ConvertFrom(value)
                    MyBase.Checked = True
                Else
                    Throw New InvalidCastException("Cannot convert DateTime value from " & value.GetType().ToString() & " type")
                End If

            Catch ex As InvalidCastException
                ' We catch specific cast exceptions
                Throw ex

            Catch ex As Exception
                ' We catch all other types of exceptions
                Throw ex

            Finally
                Me.ResumeLayout()

            End Try

            ' If there are pending changes, invoke OnValueChanged
            If m_pendingChanges Then
                OnValueChanged(EventArgs.Empty)
                OnTextChanged(EventArgs.Empty)
            End If

        End Set
    End Property

    Protected Overrides Sub OnValueChanged(eventargs As EventArgs)
        MyBase.OnValueChanged(eventargs)
        If m_pendingChanges Then
            m_pendingChanges = False
        End If
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'NDateTimePicker
        '
        Me.ShowCheckBox = True
        Me.ResumeLayout(False)

    End Sub

End Class
