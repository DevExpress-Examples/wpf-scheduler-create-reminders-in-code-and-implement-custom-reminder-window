Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Data

Namespace CustomReminderExample
	Public Class TimeSpanToNumberConverter
		Implements IValueConverter

		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
			Return DirectCast(value, TimeSpan).Minutes
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object
			Return TimeSpan.FromMinutes(System.Convert.ToDouble(value))
		End Function
	End Class
End Namespace
