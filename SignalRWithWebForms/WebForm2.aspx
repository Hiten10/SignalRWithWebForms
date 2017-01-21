<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="SignalRWithWebForms.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.8.2.min.js"></script>
    <script src="Scripts/jquery.signalR-2.2.0.min.js"></script>
   <!-- <script src="signalr/hubs" type="text/javascript"></script>-->
    <script src="hub.js"></script>
<script type="text/javascript">

    $(function () {

        // Proxy created on the fly
        var job = $.connection.jobHub;

        // Declare a function on the job hub so the server can invoke it
        job.client.displayStatus = function () {
            getData();
        };

        // Start the connection
        $.connection.hub.start();
        getData();
    });

    function getData() {
        var $tbl = $('#tblJobInfo');
        $.ajax({
            url: 'WebForm1.aspx/GetJobs',
            type: 'GET',
            contentType: 'application/json;charset=utf-8',
            datatype: 'json',
            success: function (data) {
                //alert(data);
                if (data.d.length > 0) {
                    $tbl.empty();
                    $tbl.append(' <tr><th>ID</th><th>Name</th><th>Last Executed Date</th><th>Status</th></tr>');
                    var rows = [];
                    var tempData = data.d;
                    for (var i = 0; i < tempData.length; i++) {
                        var date = eval(tempData[i].LastExecutionDate.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
                        //rows.push(' <tr><td>' + tempData[i].JobID + '</td><td>' + tempData[i].Name + '</td><td>' + tempData[i].LastExecutionDate.toString().substr(0, 10) + '</td><td>' + tempData[i].Status + '</td></tr>');
                        rows.push(' <tr><td>' + tempData[i].JobID + '</td><td>' + tempData[i].Name + '</td><td>' + date + '</td><td>' + tempData[i].Status + '</td></tr>');
                    }
                    $tbl.append(rows.join(''));
                }
            }
        });
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="tblJobInfo" style="text-align:center;margin-left:10px">
        </table>
    </div>
    </form>
</body>
</html>
