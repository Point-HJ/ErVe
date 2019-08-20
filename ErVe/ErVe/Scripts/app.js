var ViewModel = function () {
    var self = this;
    self.forms = ko.observableArray();
    self.error = ko.observable();

    var FormsUri = '/api/forms/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllForms() {
        ajaxHelper(FormsUri, 'GET').done(function (data) {
            self.forms(data);
        });
    }

    // Fetch the initial data.
    getAllForms();
};

ko.applyBindings(new ViewModel());