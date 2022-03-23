const { data } = require("jquery");

$(function () {

    function WireUpDatePicker()
    {
        const AddMonths = 2;
        var currDate = new Date();
        $('.datepicker').datepicker(
            {
                dateFormat: 'yy-mm-dd',
                minDate: currDate,
                maxDate: AddSubstractMonths(currDate, AddMonths)
            }
        );
    }
    WireUpDatePicker();
        
    });
