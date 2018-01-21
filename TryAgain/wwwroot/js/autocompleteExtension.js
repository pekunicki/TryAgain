function initAutoCompleteField(autoCompleteIdField, sourceToFetchData, functionOnSuccess, functionOnSelect) {
    $(document).ready(function () {
        $(autoCompleteIdField).autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: sourceToFetchData,
                    type: 'GET',
                    cache: false,
                    data: request,
                    dataType: 'json',
                    success: function (data) {
                        functionOnSuccess(data, response);
                    }
                });
            },
            select: function (event, ui) {
                functionOnSelect(event, ui);
                return false;
            }
        });
    });
}