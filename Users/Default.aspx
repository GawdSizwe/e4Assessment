<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Users._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 83vh; overflow-y: scroll;">
        <table id="UsersTable" class="table table-hover table-bordered table-condensed" style="width: 98%;">
            <thead style="background-color: #8dc73f; color: white; position: sticky; top: 49px; z-index: 100; font-size: 14px; font-weight: 600;">
                <tr>
                    <th>ID</th>
                    <th>Names</th>
                    <th>Surname</th>
                    <th>Cellphone Number</th>
                </tr>
            </thead>
        </table>
    </div>
    
<script>
    $(document).ready(function () {
        var jsondata = {
            "Name": "Test"
        };
        CreateTable();
        $.ajax({
            type: "POST",
            url: 'Default.aspx/GetUsers',
            data: JSON.stringify({ "data": jsondata }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                document.getElementById("HiddenUsersList").value = r.d;
                console.log(JSON.parse($("#HiddenUsersList").val()));
                table.destroy();
                CreateTable();
                //alert(" Event hit " + "dateText:  " + dateText);
            },
            error: function (error) {
                alert(error);
            }
        });
        console.log("Running");
    })
    function CreateTable() {
        //console.log(JSON.parse($("#HiddenUsersList").val()));
        table = $("#UsersTable").DataTable({
            dom: '<lf<t>>p',
            oLanguage: {
                sLengthMenu: "Display: _MENU_",
                sInfo: "Displaying _START_ to _END_ of _TOTAL_ loads"
            },
            lengthMenu: [[10, 20, 30, -1], [10, 20, 30, "All"]],
            processing: true,
            fixedHeader: true,
            serverSide: false,
            paging: true,
            info: false,
            rowId: "OrderNo",
            data: JSON.parse($("#HiddenMultiOrderEditList").val()),
            columns: [
                {
                    className: "row-select",
                    data: "ID"
                },
                {
                    className: "row-select",
                    data: "Names"
                },
                {
                    className: "row-select",
                    data: "Surname"
                },
                {
                    className: "row-select",
                    data: "CellNo"
                }
            ],
            select: {
                style: 'os',
                selector: 'td:first-child'
            },
            bLengthChange: true,
            ordering: false,
            fnRowCallback: function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
                $(nRow).closest('tr').addClass(aData.colClass);
            }
        });
    }
</script>
</asp:Content>
