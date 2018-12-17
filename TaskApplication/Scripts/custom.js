

function DataSave() {
    var vartxtName = "", vartxtDesc = "", vartxtCost = "", varddlPrioritylist = "";
    vartxtName = $("#txtName").val();
    vartxtDesc = $("#txtDesc").val();
    vartxtCost = $("#txtCost").val();
    varddlPrioritylist = $("#ddlPrioritylist").val();

    var sUrl = '<%=System.Configuration.ConfigurationManager.AppSettings["APIUrl"].ToString() %>';

    model = {
        Name: vartxtName,
        Description: vartxtDesc,
        EstimatedCost: vartxtCost,
        PriorityID: varddlPrioritylist
    };
    ClearControl();
    $.ajax({
        type: "POST",
        contentType: "application/json",
        //dataType: 'json',
        data: JSON.stringify(model),
        url: sUrl + "/api/Task/TaskSave",
        async: false,
        success: function (data) {
            alert("Data Save Successfully.");
        },
        complete: function () {
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        }

    });
}

function ClearControl() {
    $('input#txtName').val(''),
    $('input#txtDesc').val('');
    $('input#txtCost').val('');
    $("#ddlPrioritylist").val("Select");
}
