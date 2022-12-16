Imports System
Imports System.Globalization
Imports System.Windows.Data

Namespace CustomReminderExample

    Public Class TimeSpanToNumberConverter
        Implements IValueConverter

        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
            Return CType(value, TimeSpan).Minutes
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return TimeSpan.FromMinutes(System.Convert.ToDouble(value))
        End Function
    End Class
End Namespace
