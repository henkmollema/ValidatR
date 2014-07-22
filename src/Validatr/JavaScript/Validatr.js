var Validatr = {
    summarySelector: '#validatr-summary ',
    summaryElememt: 'li',

    init: function (validatrOptions) {
        /// <summary>
        /// Initializes Validatr with the specified options.
        /// </summary>
        /// <param name="validatrOptions" type="Object">An object containing the configuration for Validatr.</param>

        if (validatrOptions["summarySelector"]) {
            this.summarySelector = validatrOptions["summarySelector"];
        }

        if (validatrOptions['summaryElement']) {
            this.summaryElememt = validatrOptions['summaryElement'];
        }
    },

    proccess: function (xhr) {
        /// <summary>
        /// Processes the XHR response containing the model state.
        /// </summary>
        /// <param name="xhr" type="Object">The XHR object of the response.</param>

        var response = JSON.parse(xhr.responseText);
        var fields = Object.keys(response);
        var $summary = $(this.summarySelector);
        if ($summary.length == 0) {
            console.error('Could not find a summary element with selector \'' + this.summarySelector + '\'. Use `Validatr.init()` to specify a custom selector.');
        }

        this.clearSummary();
        var summaryElement = this.summaryElememt;

        fields.forEach(function (field) {
            if (response[field].Errors && response[field].Errors.length > 0) {
                response[field].Errors.forEach(function (e) {
                    $summary.append('<' + summaryElement + '>' + e.ErrorMessage + '</' + summaryElement + '>');
                });
            }
        });
    },

    clearSummary: function () {
        /// <summary>
        /// Clears the content of the summary.
        /// </summary>

        $(this.summarySelector).html('');
    }
}