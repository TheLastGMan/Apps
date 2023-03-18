@ModelType Web.ScheduleModel
@Code
    ViewData("Title") = "PINZ Schedule Viewer"
End Code

<style>
    table#schedule {
        border-collapse:separate;
        border-spacing:0;
        width:75%;
        margin:10px auto;
        text-align:center;
    }
        table#schedule tr {
            background-color: #DDD;
        }
        table#schedule tr:nth-of-type(even) {
            background-color: #BBB;
        }

        table#schedule td[colspan="2"] {
            text-align: center;
            font-weight: bold;
            padding:10px;
            border-radius: 10px;
            border:1px solid #000;
        }

        table#schedule tbody td {
            border-radius: 0 10px 10px 0;
            padding: 10px;
            margin: 0;
            text-align:left;
            border:1px solid black;
            border-style:none solid dashed none;
        }
        table#schedule tbody td:first-child {
            border-radius:10px 0 0 10px;
            font-size:1.5em;
            text-align:right;
            border-left-style:solid;
            border-right-style:dotted;
        }
        table#schedule tbody tr:last-child td {
            border-bottom-style: none;
        }

        table#schedule input[type=submit], input[type=date] {
            border:1px solid #000;
            border-radius: 10px;
            width:200px;
            margin-left:5px;
            padding:2px 10px;
        }
        table#schedule input[type=submit]:hover {
            background-color: #296C86;
        }
        table#schedule input[type=submit] {
            background-color: #78C1DD;
            padding: 10px;
            font-weight:bold;
            font-size:1.1em;
        }

</style>

@Using Html.BeginForm()
    @<table id="schedule">
        <thead>
            <tr>
                <td colspan="2">
                    <h1>Custom Schedule Viewer</h1>
                </td>
            </tr>
        </thead>
        <tbody>    
            <tr>
                <td style="width:50%;">
                    @Html.LabelFor(Function(f) f.Departments, "Department : ")
                </td>
                <td>
                    @Html.DropDownListFor(function(f) f.department, Model.Departments, New With {.data_theme = "a"})
                </td>
            </tr>
            <tr>
                <td>
                   Out Time :&nbsp;
                </td>
                <td>
                    @Html.DropDownListFor(Function(f) f.ShowOutTime, Model.YesNoCB, New With {.data_theme = "a", .data_role = "slider"})
                </td>
            </tr>
            <tr>
                <td>
                   Last Names :&nbsp;
                </td>
                <td>
                    @Html.DropDownListFor(Function(f) f.ShowLastNames, Model.YesNoCB, New With {.data_theme="a",.data_role="slider"})
                </td>
            </tr>
            <tr>
                <td>
                   Jobs :&nbsp;
                </td>
                <td>
                    @Html.DropDownListFor(Function(f) f.Jobs, Model.YesNoCB, New With {.data_theme="a",.data_role="slider"})
                </td>
            </tr>
            @If User.Identity.IsAuthenticated Then
                @<tr>
                    <td>
                        Telephone :&nbsp;
                    </td>
                    <td>
                        @Html.DropDownListFor(Function(f) f.Telephone, Model.YesNoCB, New With {.data_theme="a",.data_role="slider"})
                    </td>
                </tr>                
            End If
            <tr>
                <td>
                   Availability :&nbsp;
                </td>
                <td>
                    @html.DropDownListFor(Function(f) f.Availability, Model.YesNoCB, New With {.data_theme="a",.data_role="slider"})
                </td>
            </tr>
            <tr>
                <td>
                   Unscheduled :&nbsp;
                </td>
                <td>
                    @Html.DropDownListFor(Function(f) f.Unscheduled, Model.YesNoCB, New With {.data_theme="a",.data_role="slider"})
                </td>
            </tr>
            <tr>
                <td>
                   Start Date :&nbsp;
                </td>
                <td>
                    @Html.TextBoxFor(Function(f) f.StartDate, New With {.type = "date", .value = Model.StartDate.ToString("MM/dd/yyyy")})
                </td>
            </tr>
            <tr>
                <td>
                   End Date :&nbsp;
                </td>
                <td>
                    @Html.TextBoxFor(Function(f) f.EndDate, New With {.type = "date", .value = Model.EndDate.ToString("MM/dd/yyyy")})
                </td>
            </tr>
        </tbody>
        <tfoot>
                <tr>
                    <td colspan="2">
                        <input type="submit" id="formsubmit" value="View Schedule" class="viewschedule" />
                    </td>
                </tr>
        </tfoot>
        </table>
End Using
