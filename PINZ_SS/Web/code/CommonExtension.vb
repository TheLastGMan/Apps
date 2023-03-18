Imports System.Runtime.CompilerServices
Imports System.Linq.Expressions

Public Module CommonExtension

    <Extension>
    Public Function FieldNameFor(Of T, TResult)(html As HtmlHelper(Of T), expression As Expression(Of Func(Of T, TResult))) As String
        Return html.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression))
    End Function

    <Extension>
    Public Function FieldIdFor(Of T, TResult)(html As HtmlHelper(Of T), expression As Expression(Of Func(Of T, TResult))) As String
        Dim id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression))
        ' because "[" and "]" aren't replaced with "_" in GetFullHtmlFieldId
        Return id.Replace("[", "_").Replace("]", "_")
    End Function

End Module
