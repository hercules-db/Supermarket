'use strict';

$(function () {
    
    $(function () {
        $("#locationSource, #locationResult, #destination").hide();
        registerEventHandlers();
    });

    function registerEventHandlers() {
        $("#sourceSelect").change(showDestinationOptions);

    } 

    function showDestinationOptions() {
        
        var $sourceFileType = $("#sourceSelect").val();        
        $("#locationSource, #locationResult, #destination").show();
        $("#destinationSelect").val("none");
        $("#destinationSelect option").hide();
        switch ($sourceFileType) {
        case "oracle":
                $('#destinationSelect option[value="mssql"]').show();
                break;
            case "mssql":
                $('#destinationSelect option[value="pdf"]').show();
                $('#destinationSelect option[value="mysql"]').show();
                $('#destinationSelect option[value="json"]').show();
                $('#destinationSelect option[value="xml"]').show();
                break;
            case "xml":
            case "zip":
                $('#destinationSelect option[value="mssql"]').show();
                break;
            case "json":
                $('#destinationSelect option[value="mongo"]').show();
                break;
            case "mysql":
                $('#destinationSelect option[value="excel"]').show();
                $('#destinationSelect option[value="excel"]').show();
                break;
            case "sqlite":
                $('#destinationSelect option[value="excel"]').show();
                break;
        default:
        }
    }


    function showErrorMessage(msg) {
        noty({
            text: msg,
            type: 'error',
            layout: 'topCenter',
            timeout: 5000
        });
    }
    
    function showInfoMessage(msg) {
        noty({
            text: msg,
            type: 'info',
            layout: 'topCenter',
            timeout: 3000
        });
    }
});